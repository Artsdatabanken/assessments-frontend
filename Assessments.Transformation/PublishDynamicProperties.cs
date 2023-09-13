using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Assessments.Transformation.Models;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;
using static Assessments.Mapping.RedlistSpecies.Source.Rodliste2019;

namespace Assessments.Transformation
{
    internal class PublishDynamicProperties
    {
        private static void ImportRedlist2021(IDocumentStore store)
        {
            var batch = new List<DynamicProperty>();
            //var httpClient = new HttpClient();
            //var client = new RedlistApi.Client("https://assessments-fe.test.artsdatabanken.no/", httpClient);
            //var result = client.Api_Species2021Async().GetAwaiter().GetResult();
            using (var reader = new StreamReader("rødliste-2021.csv")) // todo - erstatt med bruk av api
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.GetCultureInfo("nb-NO"))
            {
                DetectDelimiter = true,
                PrepareHeaderForMatch = args1 => args1.Header.Replace(" ", "_").ToLower()
            }))
            {
                var records = csv.GetRecords<dynamic>();
                foreach (var record in records)
                {
                    string reference = ("ScientificNames/" + record.vitenskapelig_navn_id.ToString());
                    var prop = new DynamicProperty()
                    {
                        Id = "DynamicProperty/Rodliste2021-" + record.id_for_vurderingen,
                        References = new[] { reference },
                        Properties = new[]
                        {
                            new DynamicProperty.Property()
                            {
                                Name = "Kategori", Value = record.kategori_2021.Substring(0, 2),
                                Properties = new[]
                                {
                                    new DynamicProperty.Property() { Name = "Kontekst", Value = "Rødliste 2021" },
                                    new DynamicProperty.Property()
                                        { Name = "scientificNameID", Value = record.vitenskapelig_navn_id },
                                    new DynamicProperty.Property()
                                        { Name = "EkspertGruppe", Value = record.ekspertkomité },
                                    new DynamicProperty.Property()
                                        { Name = "Område", Value = record.vurderingsområde },
                                    new DynamicProperty.Property() { Name = "Aar", Value = "2021" },
                                    new DynamicProperty.Property()
                                    {
                                        Name = "Url",
                                        Value = "https://artsdatabanken.no/lister/rodlisteforarter/2021/" +
                                                record.id_for_vurderingen
                                    },
                                }
                            },
                        }
                    };
                    batch.Add(prop);
                    if (batch.Count <= 999) continue;
                    SaveBatch(batch, store);
                    batch = new List<DynamicProperty>();
                }
            }

            if (batch.Count > 0)
            {
                SaveBatch(batch, store);
            }
        }
        private static void ImportAlienList2023(IDocumentStore store)
        {
            var batch = new List<DynamicProperty>();
            using (var reader = new StreamReader("fremmedartslista-2023.csv")) // todo - erstatt med bruk av api
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.GetCultureInfo("nb-NO"))
            {
                DetectDelimiter = true,
                PrepareHeaderForMatch = args1 => args1.Header.Replace(" ", "_").ToLower()
            }))
            {
                var records = csv.GetRecords<dynamic>();
                foreach (var record in records)
                {
                    var vitenskapeligNavnId = record.vitenskapelig_navn_id;
                    var idForVurderingen = record.id_for_vurderingen;

                    string reference = ("ScientificNames/" + vitenskapeligNavnId.ToString());
                    var prop = new DynamicProperty()
                    {
                        Id = "DynamicProperty/FremmedArt2023-" + idForVurderingen,
                        References = new[] { reference },
                        Properties = new[]
                        {
                            new DynamicProperty.Property()
                            {
                                Name = "Kategori", Value = record.risikokategori_2023.Substring(0, 2),
                                Properties = new[]
                                {
                                    new DynamicProperty.Property() { Name = "Kontekst", Value = "Fremmedart 2023" },
                                    new DynamicProperty.Property()
                                        { Name = "scientificNameID", Value = vitenskapeligNavnId },
                                    new DynamicProperty.Property()
                                        { Name = "EkspertGruppe", Value = record.ekspertkomité },
                                    new DynamicProperty.Property()
                                        { Name = "Område", Value = record.vurderingsområde == "Fastlands-Norge med havområder" ? "Norge" : "Svalbard" },
                                    new DynamicProperty.Property() { Name = "Aar", Value = "2023" },
                                    new DynamicProperty.Property()
                                    {
                                        Name = "Url",
                                        Value = "https://artsdatabanken.no/lister/fremmedartslista/2023/" +
                                                idForVurderingen
                                    },
                                    new DynamicProperty.Property() {Name = "Fremmedartsstatus" , Value = record.fremmedartsstatus}
                                }
                            },
                        }
                    };
                    batch.Add(prop);
                    if (batch.Count <= 999) continue;
                    SaveBatch(batch, store);
                    batch = new List<DynamicProperty>();
                }
            }

            if (batch.Count > 0)
            {
                SaveBatch(batch, store);
            }
        }

        private static void SaveBatch(List<DynamicProperty> batch, IDocumentStore documentStore)
        {
            using var session = documentStore.OpenSession();
            foreach (var dynamicProperty in batch)
            {
                session.Store(dynamicProperty);
            }
            session.SaveChanges();
        }
    }
}
