using System.Collections.Generic;
using System.Linq;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Transformation.Models;
using System.Threading.Tasks;
using Assessments.Shared.Helpers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Assessments.Shared.Options;
using Assessments.Transformation.Helpers;
using AutoMapper;
using Assessments.Mapping.RedlistSpecies;
using Raven.Client.Document;
using Raven.Client;
using System;
using Raven.Abstractions.Commands;
using static Assessments.Mapping.RedlistSpecies.Source.Rodliste2019;
using Raven.Abstractions.Extensions;

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
            var fileContent = await Storage.DownloadFromBlob(_configuration, DataFilenames.AlienSpecies2023);
            var speciesAssessments = JsonSerializer.Deserialize<IList<AlienSpeciesAssessment2023>>(fileContent)?.AsQueryable();

            return  speciesAssessments.Select(x => new DynamicProperty
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
                            new DynamicProperty.Property() { Name = "Fremmedartsstatus" , Value = x.AlienSpeciesCategory.ToString()} //TODO, IMPORTANT! - check that this tranformation is correct
                        }
                    }
                }
            }).
            ToList();
        }

        public static async Task UploadDynamicPropertiesToTaxonApi(IConfigurationRoot configuration)
        {
            var publishDynamicProperties = new PublishDynamicProperties(configuration);
            var dynamicPropertiesFromStorageAccount = await publishDynamicProperties.ImportAlienList2023();
            dynamicPropertiesFromStorageAccount.AddRange(await publishDynamicProperties.ImportRedlist2021());

            var DocumentStore = DocumentStoreHolder.Store;
            var ravenSession = DocumentStoreHolder.RavenSession;

            //ravenSession.Load<DynamicProperty>("\"DynamicProperty/FremmedArt2023-\"");//NOTE: we might need a Databank.Domain.Content.Node type here from data.artsdatabanken.no


            DeleteExistingDynamicProperties(ravenSession, "DynamicProperty/Rodliste2021");
            DeleteExistingDynamicProperties(ravenSession, "DynamicProperty/Fremmedart2023"); //ravenSession.Query<DynamicProperty>().Where(x => x.Id.StartsWith("DynamicProperty/Fremmedart2023")).Skip(pointer).Take(batchSize).ToArray();

            //// Delete dynamicProperties in RavenDb that do not exist in the latest dynamicProperty collection

            //// GET dynamicProperties from RavenDb pertaining alien species 2023 assessments
            //var queryAlienSpecies2023 = ravenSession.Advanced.DocumentQuery<DynamicProperty>("Raven/DocumentsByEntityName")
            //    .WhereStartsWith("__document_id", "DynamicProperty/FremmedArt2023-").ToList();

            //var queryRedlistedSpecies2021 = ravenSession.Advanced.DocumentQuery<DynamicProperty>("Raven/DocumentsByEntityName")
            //    .WhereStartsWith("__document_id", "DynamicProperty/Rodliste2021-").ToList();

            //var existingDynamicProperties = queryAlienSpecies2023.Union(queryRedlistedSpecies2021).ToList();

            ////TODO: Delete this list of dynamicProperties from RavenDb
            //var obsoleteDynamicProperties = newDynamicProperties.Except(existingDynamicProperties).ToList();


            //Store DynamicProperties in RavenDb
            StoreDynamicProperties(dynamicPropertiesFromStorageAccount, ravenSession);

            ravenSession.SaveChanges();
        }

        private static void StoreDynamicProperties(List<DynamicProperty> newDynamicProperties, IDocumentSession ravenSession)
        {
            foreach (var dynamicProperty in newDynamicProperties)
            {
                ravenSession.Store(dynamicProperty);
            }
        }

        private static void DeleteExistingDynamicProperties(IDocumentSession ravenSession, string firstPartOfDocumentName)
        {
            int pointer = 0;
            const int batchSize = 1024;

            List<DynamicProperty> getRedlistet2021;
            while (true)
            {
                //Page through the dynamicPropertis as RavenDb server per default has a limit of 128 = 2^7 result (batchSize)
                getRedlistet2021 = ravenSession.Query<DynamicProperty>().Where(x => x.Id.StartsWith(firstPartOfDocumentName)).Skip(pointer).Take(batchSize).ToList();

                if (!getRedlistet2021.Any()) break;

                foreach (var item in getRedlistet2021)
                    ravenSession.Delete<DynamicProperty>(item);

                pointer += batchSize;
            }
        }
    }
}

