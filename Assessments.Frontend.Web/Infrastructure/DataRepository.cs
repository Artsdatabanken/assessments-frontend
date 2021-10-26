using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assessments.Mapping.Models.Source.Species;
using Assessments.Mapping.Models.Species;
using Assessments.Shared.Helpers;
using AutoMapper;
using Azure.Storage.Blobs;
using CsvHelper;
using CsvHelper.Configuration;
using LazyCache;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class DataRepository
    {
        private readonly IAppCache _appCache;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<DataRepository> _logger;
        private readonly IMapper _mapper;

        private static CsvConfiguration CsvConfiguration => new(CultureInfo.InvariantCulture) { Delimiter = ";" };

        public DataRepository(IAppCache appCache, IConfiguration configuration, IWebHostEnvironment environment, ILogger<DataRepository> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
            _configuration = configuration;
            _appCache = appCache;
            _appCache.DefaultCachePolicy.DefaultCacheDurationSeconds = 86400; // 24 hours
        }

        public Task<IQueryable<T>> GetData<T>(string name)
        {
            async Task<IQueryable<T>> DeserializeData()
            {
                var fileName = Path.Combine(_environment.ContentRootPath, Constants.CacheFolder, name);
                string fileContent;

                if (File.Exists(fileName)) // use cached file
                {
                    fileContent = await File.ReadAllTextAsync(fileName);
                }
                else // download file
                {
                    var blob = new BlobContainerClient(_configuration["ConnectionStrings:AzureBlobStorage"], "assessments").GetBlobClient(name);
                    var response = await blob.DownloadContentAsync();

                    fileContent = response.Value.Content.ToString();

                    await using var writer = new StreamWriter(fileName);
                    await writer.WriteAsync(fileContent);

                    _logger.LogDebug($"Downloaded {fileName}");
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
            var transformSpeciesAssessments = bool.Parse(_configuration.GetSection("Mapping").GetSection("Redlist").GetSection("TransformSpeciesAssessments").Value);

            async Task<IQueryable<SpeciesAssessment2021>> Get()
            {
                return transformSpeciesAssessments ?
                    // transformerer modell fra "Rodliste2019"
                    _mapper.Map<IEnumerable<SpeciesAssessment2021>>(await GetData<Rodliste2019>(DataFilenames.Species2021Temp)).AsQueryable() :
                    // modell lagret som "SpeciesAssessment2021"
                    _mapper.Map<IEnumerable<SpeciesAssessment2021>>(await GetData<SpeciesAssessment2021>(DataFilenames.Species2021)).AsQueryable();
            }

            return _appCache.GetOrAddAsync($"{nameof(GetSpeciesAssessments)}", Get);
        }
    }
}