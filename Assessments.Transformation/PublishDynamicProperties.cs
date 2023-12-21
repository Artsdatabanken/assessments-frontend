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
using System.Diagnostics.CodeAnalysis;
using System.Collections;

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
            var AlienSpeciesAssessments = JsonSerializer.Deserialize<IList<AlienSpeciesAssessment2023>>(fileContent)?.AsQueryable();

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
            }).
            ToList();
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

            var newDynamicProperties = dynamicPropertiesFromStorageAccount.Except(existingDynamicProperties, comparerId).ToList();

            var compareDynamicProperties = new DynamicPropertyObjectComparer();
            var NewOrChangedDynamicProperties = dynamicPropertiesFromStorageAccount.Except(existingDynamicProperties, compareDynamicProperties).ToList();
            var changedDynamicProperties = NewOrChangedDynamicProperties.Except(newDynamicProperties, comparerId).ToList();

            var idsToDelete = changedDynamicProperties.Select(x => x.Id).ToArray();
            DeleteDynamicPropertiesByIds(ravenSession, idsToDelete);

            //Store DynamicProperties to RavenDb that are different or new in storage account
            StoreDynamicProperties(NewOrChangedDynamicProperties, ravenSession);

            ravenSession.SaveChanges();
        }

        public class DynamicPropertyIDComparer : IEqualityComparer<DynamicProperty>
        {
            public bool Equals(DynamicProperty x, DynamicProperty y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode([DisallowNull] DynamicProperty obj)
            {
                if (obj == null) { return 0; }

                return obj.Id.GetHashCode();
            }
        }

        public class DynamicPropertyObjectComparer : IEqualityComparer<DynamicProperty>
        {
            public bool Equals(DynamicProperty x, DynamicProperty y)
            {
                // If both are null, or both are the same instance, return true
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                // If one is null, return false
                if (x is null || y is null)
                {
                    return false;
                }

                return x.Id == y.Id &&
                    ((IStructuralEquatable)x.References).Equals(y.References, EqualityComparer<string>.Default) &&
                    CheckPropertiesEquality(x.Properties, y.Properties);
            }

            public int GetHashCode([DisallowNull] DynamicProperty obj)
            {
                if (obj == null) { return 0; }

                int hashId = obj.Id.GetHashCode();
                int hashReferences = ((IStructuralEquatable)obj.References).GetHashCode(EqualityComparer<string>.Default);                
                int hashProperties = ((IStructuralEquatable)obj.Properties).GetHashCode(StructuralComparisons.StructuralEqualityComparer); //NOTE: Fails here, hashProperties does not return the same code for the same values of properties.
                int HashPropertiesNew = obj.Properties?.Select(p => p.Name?.GetHashCode() + p.Value?.GetHashCode() + p.Properties?.Select(p2 => p2.Name?.GetHashCode() + p2.Value?.GetHashCode() ?? 0).Sum()).Sum() ?? 0; //NOTE: calculates hash codes 2 levels down into the recurrent property object, this should be sufficient for assessments

                return HashCode.Combine(hashId, hashReferences, HashPropertiesNew);                
            }
        }

        private static bool CheckPropertiesEquality(DynamicProperty.Property[] xProps, DynamicProperty.Property[] yProps)
        {
            if (xProps == yProps) return true;
            if (xProps is null || yProps is null) return false;
            if (xProps.Length != yProps.Length) return false;

            for (int i = 0; i < xProps.Length; i++)
            {
                if (xProps[i].Name != yProps[i].Name || xProps[i].Value != yProps[i].Value)
                    return false;

                if (!CheckPropertiesEquality(xProps[i].Properties, yProps[i].Properties))
                    return false;
            }

            return true;
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

                pointer += batchSize;
            }

            return allAssessments;
        }

        private static bool CompareProperties(DynamicProperty.Property[] x, DynamicProperty.Property[] y)
        {
            bool areEqual = true;

            if (x == y) return true;
            if (x == null || y == null || x.Length != y.Length) return false;


            // Compare the elements using the Equals method
            for (int i = 0; i > x.Length; i++)
            {
                if (x[i].Name != y[i].Name || x[i].Value != y[i].Value || !CompareProperties(x[i].Properties, y[i].Properties))
                {
                    areEqual = false;
                    break;
                }
            }

            return areEqual;
        }
    }
}

