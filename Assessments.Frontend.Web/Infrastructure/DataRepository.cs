using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Source;
using Assessments.Mapping.RedlistSpecies;
using Assessments.Mapping.RedlistSpecies.Source;
using Assessments.Shared.Helpers;
using Assessments.Shared.Options;
using AutoMapper;
using Azure.Storage.Blobs;
using CsvHelper;
using CsvHelper.Configuration;
using DocumentFormat.OpenXml.Wordprocessing;
using LazyCache;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class DataRepository
    {
        private readonly IAppCache _appCache;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<DataRepository> _logger;
        private readonly IMapper _mapper;
        private readonly IOptions<ApplicationOptions> _options;
        private readonly ILoggerFactory _loggerFactory;
        private readonly string _path;
        private IAppCache appCache;
        private IConfiguration configuration;

        private static CsvConfiguration CsvConfiguration => new(CultureInfo.InvariantCulture) { Delimiter = ";" };

        public DataRepository(IAppCache appCache, IConfiguration configuration, IWebHostEnvironment environment, ILogger<DataRepository> logger, IMapper mapper, IOptions<ApplicationOptions> options)
        {
            _options = options;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
            _path = Path.Combine(_environment.ContentRootPath, Constants.CacheFolder);
            _configuration = configuration;
            _appCache = appCache;
            _appCache.DefaultCachePolicy.DefaultCacheDurationSeconds = 86400; // 24 hours
        }

        //Constructor that initializes the class properties without using DI and IWebHostEnvironment as this is only available during runtime
        //This constructor can then be used from outside project scope
        public DataRepository(IAppCache appCache, IConfiguration configuration, ILogger<DataRepository> logger, IMapper mapper, IOptions<ApplicationOptions> options)
        {
            _options = options;
            _mapper = mapper;
            _logger = logger;

            // Get the path to the cache files in Assessments.Frontend.Web project
            _path = Assembly.GetExecutingAssembly().Location;
            string delimeter = "Assessments.Transformation";
            _path = _path.Split(delimeter)[0];
            _path = Path.Combine(_path, "Assessments.Frontend.Web", Constants.CacheFolder);

            _configuration = configuration;
            _appCache = appCache;
            _appCache.DefaultCachePolicy.DefaultCacheDurationSeconds = 86400; // 24 hours
        }

        public DataRepository(IAppCache appCache, IConfiguration configuration)
        {
            this.appCache = appCache;
            this.configuration = configuration;
        }

        public Task<IQueryable<T>> GetData<T>(string name)
        {
            async Task<IQueryable<T>> DeserializeData()
            {
                var fileName = Path.Combine(_path, name);
                string fileContent;

                if (File.Exists(fileName)) // use cached file
                {
                    fileContent = await File.ReadAllTextAsync(fileName);
                }
                else // download file
                {
                    var connectionString = _configuration["ConnectionStrings:AzureBlobStorage"];
                    if (string.IsNullOrWhiteSpace(connectionString)) throw new System.Exception("Missing required config for azure blog storage: ConnectionStrings:AzureBlobStorage");
                    var blob = new BlobContainerClient(connectionString, "assessments").GetBlobClient(name);
                    var response = await blob.DownloadContentAsync();

                    fileContent = response.Value.Content.ToString();

                    await using var writer = new StreamWriter(fileName);
                    await writer.WriteAsync(fileContent);

                    _logger.LogInformation($"Downloaded {fileName}");
                }

                if (!name.EndsWith(".csv")) // handle json
                    return JsonSerializer.Deserialize<IList<T>>(fileContent)?.AsQueryable();

                using var reader = new StringReader(fileContent);
                using var csv = new CsvReader(reader, CsvConfiguration);

                return csv.GetRecords<T>().ToList().AsQueryable();
            }

            return _appCache.GetOrAddAsync($"{nameof(DataRepository)}-{name}", DeserializeData);
        }


        public Task<IQueryable<SpeciesAssessment2021>> GetSpeciesAssessments()
        {
            async Task<IQueryable<SpeciesAssessment2021>> Get()
            {
                return _options.Value.Species2021.TransformAssessments
                    ?
                    // transformerer modell fra "Rodliste2019"
                    _mapper.Map<IEnumerable<SpeciesAssessment2021>>(await GetData<Rodliste2019>(DataFilenames.Species2021Temp)).AsQueryable() :
                    // returnerer modell som allerede er transformert
                    await GetData<SpeciesAssessment2021>(DataFilenames.Species2021);
            }

            return _appCache.GetOrAddAsync($"{nameof(GetSpeciesAssessments)}", Get);
        }

        public Task<IQueryable<AlienSpeciesAssessment2023>> GetAlienSpeciesAssessments()
        {
            async Task<IQueryable<AlienSpeciesAssessment2023>> Get()
            {
                return _options.Value.AlienSpecies2023.TransformAssessments
                    ?
                    // transformerer modell fra "FA4"
                    _mapper.Map<IEnumerable<AlienSpeciesAssessment2023>>(await GetData<FA4>(DataFilenames.AlienSpecies2023Temp)).AsQueryable() :
                    // returnerer modell som allerede er transformert
                    await GetData<AlienSpeciesAssessment2023>(DataFilenames.AlienSpecies2023);
            }

            return _appCache.GetOrAddAsync($"{nameof(GetSpeciesAssessments)}", Get);
        }
    }
}