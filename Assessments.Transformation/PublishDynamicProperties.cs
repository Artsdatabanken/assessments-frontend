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
                            new DynamicProperty.Property() { Name = "Fremmedartsstatus" , Value = x.AlienSpeciesCategory.ToString()}                            
                        }
                    }
                }
            }).
            ToList();
        }

        public static async Task UploadDynamicPropertiesToTaxonApi(IConfigurationRoot configuration)
        {
            var publishDynamicProperties = new PublishDynamicProperties(configuration);
            var newDynamicProperties = await publishDynamicProperties.ImportAlienList2023();
            newDynamicProperties.AddRange(await publishDynamicProperties.ImportRedlist2021());


            var DocumentStore = DocumentStoreHolder.Store;
            var ravenSession = DocumentStoreHolder.RavenSession;

            //ravenSession.Load<DynamicProperty>("\"DynamicProperty/FremmedArt2023-\"");//NOTE: we might need a Databank.Domain.Content.Node type here from data.artsdatabanken.no


            // Delete dynamicProperties in RavenDb that do not exist in the latest dynamicProperty collection

            // GET dynamicProperties from RavenDb pertaining alien species 2023 assessments
            var queryAlienSpecies2023 = ravenSession.Advanced.DocumentQuery<DynamicProperty>("Raven/DocumentsByEntityName")
                .WhereStartsWith("__document_id", "DynamicProperty/FremmedArt2023-");

            var queryRedlistedSpecies2021 = ravenSession.Advanced.DocumentQuery<DynamicProperty>("Raven/DocumentsByEntityName")
                .WhereStartsWith("__document_id", "DynamicProperty/Rodliste2021-");

            var existingDynamicProperties = queryAlienSpecies2023.Union(queryRedlistedSpecies2021).ToList();

            //Delete this list of dynamicProperties from RavenDb
            var obsoleteDynamicProperties = newDynamicProperties.Except(existingDynamicProperties).ToList();
      

            //Store DynamicProperties in RavenDb
            ravenSession.Store(newDynamicProperties);
            ravenSession.SaveChanges();
        }
        // The `DocumentStoreHolder` class holds a single Document Store instance.

        private static void DeleteDocumentsById(string[] toDeleteDocumentIds, IDocumentStore documentstore)
        {
            var pointer = 0;
            const int Batchsize = 500;
            var errorcount = 0;
            while (true)
            {
                var batch = toDeleteDocumentIds.Skip(pointer).Take(Batchsize).Distinct().ToArray();
                if (!batch.Any()) break;
                try
                {
                    //var ses = this.DocumentCacheStore.Session;
                    var commandlist = batch.Select(deletedRecordId => new DeleteCommandData { Key = deletedRecordId })
                        .Cast<ICommandData>().ToList();
                    using (var session = documentstore.OpenSession())
                    {
                        session.Advanced.DocumentStore.DatabaseCommands.Batch(commandlist);
                        session.SaveChanges();
                    }

                    pointer += Batchsize;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //logger.Error(e, e.Message);
                    errorcount++;
                    if (errorcount > 20)
                    {
                        //logger.Error(e, "For mange feil (mer enn 20) på sletting av Document via id - hopper ut");
                        throw new Exception("For mange feil (mer enn 20) på sletting av Document via id - hopper ut", e);
                    }
                }
            }
        }

    }
}

