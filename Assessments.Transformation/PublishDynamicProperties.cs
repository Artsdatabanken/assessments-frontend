using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Transformation.Models;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;
using static Assessments.Mapping.RedlistSpecies.Source.Rodliste2019;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Shared.Helpers;
using System.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Assessments.Shared.Options;
using LazyCache;
using AutoMapper;

namespace Assessments.Transformation
{
    public class PublishDynamicProperties
    {
        private readonly DataRepository _dataRepository;
        private readonly IOptions<ApplicationOptions> _options;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DataRepository> _logger;
        private readonly IMapper _mapper;
        private IAppCache _appCache;

        public PublishDynamicProperties(IConfiguration configuration)
        {
            ApplicationOptions applicationOptions = new ApplicationOptions
            {
                AlienSpecies2023 = new AlienSpecies2023Options
                {
                    Enabled = true,
                    IsHearing = true,
                    TransformAssessments = true
                },
                Species2021 = new Species2021Options
                {
                    TransformAssessments = true
                }
            };
            
            _options = Options.Create(applicationOptions);

            //The AutoMapper method AddMaps parameter refers to the assembly files in the Assessment.Mapping project. It will find the maps contained.
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddMaps(Constants.AssessmentsMappingAssembly));
            _mapper = new Mapper(mapperConfiguration);
           
            _configuration = configuration;
            _appCache = new CachingService();
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var _logger = loggerFactory.CreateLogger<DataRepository>();
 

            _dataRepository = new DataRepository(_appCache, configuration, _logger, _mapper, _options );
        }


        public async Task<List<DynamicProperty>> ImportRedlist2021()
        {
            var batch = new List<DynamicProperty>();
            //var httpClient = new HttpClient();
            //var client = new RedlistApi.Client("https://assessments-fe.test.artsdatabanken.no/", httpClient);
            //var result = client.Api_Species2021Async().GetAwaiter().GetResult();

            var AlienSpeciesAssessments = await _dataRepository.GetSpeciesAssessments();

            return AlienSpeciesAssessments.Select(x => new DynamicProperty
            {                
                Id = "DynamicProperty/Rodliste2021-" + x.Id.ToString(),
                References = new[] { "ScientificNames/" + x.ScientificNameId.ToString() },
                Properties = new[]
                {
                    new DynamicProperty.Property
                    {
                        Name = "Kategori",
                        Value = x.Category.ToString().Substring(0, 2),
                        Properties = new []
                        {
                            new DynamicProperty.Property() { Name = "Kontekst", Value = "Rødliste 2021" },
                            new DynamicProperty.Property() { Name = "scientificNameID", Value = x.ScientificNameId.ToString() },
                            new DynamicProperty.Property() { Name = "EkspertGruppe", Value = x.ExpertCommittee },
                            new DynamicProperty.Property() { Name = "Område", Value = x.AssessmentArea },
                            new DynamicProperty.Property() { Name = "Aar", Value = "2021" },
                            new DynamicProperty.Property() { Name = "Url", Value = "https://artsdatabanken.no/lister/rodlisteforarter/2021/" + x.Id.ToString()
                            }
                        }
                    }
                }
            }).
            ToList();
        }


        public async Task<List<DynamicProperty>> ImportAlienList2023()
        {
            var batch = new List<DynamicProperty>();

            var AlienSpeciesAssessments = await _dataRepository.GetAlienSpeciesAssessments();

            return  AlienSpeciesAssessments.Select(x => new DynamicProperty
            {
                Id = "DynamicProperty/FremmedArt2023-" + x.Id.ToString(),
                References = new[] { "ScientificNames/" + x.ScientificName.ScientificNameId.ToString() },
                Properties = new[]
                {
                    new DynamicProperty.Property
                    {
                        Name = "Kategori",
                        Value = x.Category.ToString().Substring(0, 2),
                        Properties = new []
                        {
                            new DynamicProperty.Property() { Name = "Kontekst", Value = "Fremmedart 2023" },
                            new DynamicProperty.Property() { Name = "scientificNameID", Value = x.ScientificName.ScientificNameId.ToString() },
                            new DynamicProperty.Property() { Name = "EkspertGruppe", Value = x.ExpertGroup },
                            new DynamicProperty.Property() { Name = "Område", Value = x.EvaluationContext.DisplayName()  },
                            new DynamicProperty.Property() { Name = "Aar", Value = "2023" },
                            new DynamicProperty.Property() { Name = "Url", Value = "https://artsdatabanken.no/lister/fremmedartslista/2023/" + x.Id.ToString() },
                            new DynamicProperty.Property() { Name = "Fremmedartsstatus" , Value = x.AlienSpeciesCategory.ToString()}
                            }
                        }
                    }
                }
            }).
            ToList();
        }
    }
}

