using System.Collections.Generic;
using System.Linq;
using Assessments.Mapping.AlienSpecies.Model;
using System.Threading.Tasks;
using Assessments.Shared.Helpers;
using System.Text.Json;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Microsoft.Extensions.Configuration;
using Assessments.Transformation.Helpers;
using Assessments.Mapping.RedlistSpecies;
using Assessments.Transformation.DynamicProperties;
using Databank.Domain.Taxonomy;
using Raven.Client;

namespace Assessments.Transformation
{
    public class PublishDynamicProperties
    {
        private readonly IConfigurationRoot _configuration;

        public PublishDynamicProperties(IConfigurationRoot configuration)
        {
            _configuration = configuration;
            //var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        }
        
        public async Task<List<DynamicProperty>> ImportRedlist2021()
        {
            var fileContent = await Storage.DownloadFromBlob(_configuration, DataFilenames.Species2021);
            var speciesAssessments = JsonSerializer.Deserialize<IList<SpeciesAssessment2021>>(fileContent)?.AsQueryable();
            return speciesAssessments.Select(x => new DynamicProperty
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
                            new DynamicProperty.Property() { Name = "Område", Value = x.AssessmentArea == "N"  ? "Norge" : "Svalbard" },
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
            var fileContent = await Storage.DownloadFromBlob(_configuration, DataFilenames.AlienSpecies2023);
            var AlienSpeciesAssessments = JsonSerializer.Deserialize<IList<AlienSpeciesAssessment2023>>(fileContent)?.AsQueryable();

            var list = AlienSpeciesAssessments.Select(x => new DynamicProperty
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
                                new DynamicProperty.Property() { Name = "Område", Value = x.EvaluationContext == AlienSpeciesAssessment2023EvaluationContext.N ? "Norge" : "Svalbard" }, // must match expected values being in use
                                new DynamicProperty.Property() { Name = "Aar", Value = "2023" },
                                new DynamicProperty.Property() { Name = "Url", Value = "https://artsdatabanken.no/lister/fremmedartslista/2023/" + x.Id.ToString() },
                                new DynamicProperty.Property() { Name = "Fremmedartsstatus" , Value = x.AlienSpeciesCategory.DisplayName()}
                            }
                        }
                    }
                }).
                ToList();
            return  list;
        }

        public static async Task UploadDynamicPropertiesToTaxonApi(IConfigurationRoot configuration)
        {
            var publishDynamicProperties = new PublishDynamicProperties(configuration);
            var dynamicPropertiesFromStorageAccount = await publishDynamicProperties.ImportAlienList2023();
            dynamicPropertiesFromStorageAccount.AddRange(await publishDynamicProperties.ImportRedlist2021());

            var ravenSession = DocumentStoreHolder.RavenSession;        

            var existingDynamicProperties = GetExistingDynamicProperties(ravenSession, "DynamicProperty/Rodliste2021");
            existingDynamicProperties.AddRange(GetExistingDynamicProperties(ravenSession, "DynamicProperty/Fremmedart2023")); 

            var comparerId = new DynamicPropertyIDComparer();            
            var obsoletDynamicProperties = existingDynamicProperties.Except(dynamicPropertiesFromStorageAccount, comparerId).ToList();

            //Delete dynamicProperties stored in RavenDb that do not exist in Storage Account
            DeleteDynamicProperties(ravenSession, obsoletDynamicProperties);

            var compareDynamicProperties = new DynamicPropertyObjectComparer();
            var NewOrChangedDynamicProperties = dynamicPropertiesFromStorageAccount.Except(existingDynamicProperties, compareDynamicProperties).ToList();

            // avoid problems with dynamicproperties already in the session by id
            ravenSession.Advanced.Clear();

            //Store DynamicProperties to RavenDb that are different or new in storage account
            StoreDynamicProperties(NewOrChangedDynamicProperties, ravenSession);

            ravenSession.SaveChanges();
        }

        private static void DeleteDynamicProperties(IDocumentSession ravenSession, List<DynamicProperty> obsoletDynamicProperties)
        {
            // Delete dynamicProperties in RavenDb that do not exist in the latest dynamicProperty collection
            foreach (var item in obsoletDynamicProperties)
                ravenSession.Delete<DynamicProperty>(item);
        }

        private static void DeleteDynamicPropertiesByIds(IDocumentSession ravenSession, string[] ids)
        {
            foreach (var item in ids)
                ravenSession.Delete(item);
        }

        private static void StoreDynamicProperties(List<DynamicProperty> newDynamicProperties, IDocumentSession ravenSession)
        {
            foreach (var dynamicProperty in newDynamicProperties)
            {
                ravenSession.Store(dynamicProperty);
            }
        }

        private static List<DynamicProperty> GetExistingDynamicProperties(IDocumentSession ravenSession, string firstPartOfDocumentName)
        {
            int pointer = 0;
            const int batchSize = 1024;

            List<DynamicProperty> assessmentsBatch;
            List<DynamicProperty> allAssessments = new List<DynamicProperty>();

            while (true)
            {
                //Page through the dynamicPropertis as RavenDb server per default has a limit of 128 = 2^7 result (batchSize)
                assessmentsBatch = ravenSession.Query<DynamicProperty>().Where(x => x.Id.StartsWith(firstPartOfDocumentName))?.Skip(pointer).Take(batchSize).ToList();
                
                if (!assessmentsBatch.Any()) break;

                allAssessments.AddRange(assessmentsBatch);

                pointer += assessmentsBatch.Count; // ravendb batchLimit may be set lower at server - safer to asume this
            }

            return allAssessments;
        }
    }
}

