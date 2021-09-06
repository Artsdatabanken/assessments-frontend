using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assessments.Mapping;
using Assessments.Mapping.Models.Species;
using Microsoft.AspNetCore.Http;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Helpers
    {
        public static QueryParameters GetQueryParameters(this HttpContext context, Dictionary<string, string> parameters)
        {
            var dictionary = context.Request.Query.ToDictionary(d => d.Key, d => d.Value.ToString());

            foreach (var (key, value) in parameters)
            {
                if (dictionary.ContainsKey(key))
                    dictionary.Remove(key);

                dictionary.Add(key, value);
            }

            return new QueryParameters(dictionary);
        }

        public class QueryParameters : Dictionary<string, string>
        {
            public QueryParameters(IDictionary<string, string> dictionary) : base(dictionary) { }

            public QueryParameters WithRoute(string routeParam, string routeValue)
            {
                this[routeParam] = routeValue;

                return this;
            }
        }

        public static MemoryStream GenerateExcel(IEnumerable<SpeciesAssessment2021Export> assessments)
        {
            MemoryStream memoryStream;
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet();
                
                worksheet.Cell(1, 1).InsertTable(assessments);

                memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        public static List<string> findSelectedCategories(Dictionary<string, bool> categories, bool redlisted, bool endangered) 
        {
            List<string> selectedCategories = new List<string>();

            List<string> redlist = new List<string>
            {
                Constants.SpeciesCategories.Extinct.ShortHand,
                Constants.SpeciesCategories.CriticallyEndangered.ShortHand,
                Constants.SpeciesCategories.Endangered.ShortHand,
                Constants.SpeciesCategories.Vulnerable.ShortHand,
                Constants.SpeciesCategories.NearThreatened.ShortHand,
                Constants.SpeciesCategories.DataDeficient.ShortHand
            };

            List<string> endangeredList = new List<string>
            {
                Constants.SpeciesCategories.CriticallyEndangered.ShortHand,
                Constants.SpeciesCategories.Endangered.ShortHand,
                Constants.SpeciesCategories.Vulnerable.ShortHand
            };

            if (redlisted) 
                foreach (var category in redlist)
                    categories[category] = true;
            else if (endangered) 
                foreach (var category in endangeredList)
                    categories[category] = true;

            foreach (var entry in categories)
                if (entry.Value)
                    selectedCategories.Add(entry.Key);

            return selectedCategories;
        }

        public static char[] findSelectedCriterias(Dictionary<char, bool> criterias)
        {
            List<char> selectedCriterias = new List<char>();
            foreach (var item in criterias)
                if (item.Value)
                    selectedCriterias.Add(item.Key);
            return selectedCriterias.ToArray();
        }

        public static List<string> findSelectedAreas(Dictionary<string, bool> assessmentAreas)
        {
            List<string> selectedAreas = new List<string>();
            foreach (var item in assessmentAreas)
                if (item.Value)
                    selectedAreas.Add(item.Key);
            return selectedAreas;
        }
    }

    public static class Constants
    {
        public const string CacheFolder = "Cache";

        public const string AssessmentsMappingAssembly = "Assessments.Mapping";

        public class Filename
        {
            public const string Species2021 = "species-2021.json";

            // filnavn for modeller lagret som "RL2019"
            public const string Species2021Temp = "species-2021-temp.json";

            public const string Species2015 = "species-2015.json";

            public const string Species2006 = "species-2006.json";
        }

        public class SpeciesCategories
        {
            public class Extinct
            {
                public const string Nb = "Regionalt utdødd";
                public const string ShortHand = "RE";
            }

            public class CriticallyEndangered
            {
                public const string Nb = "Kritisk truet";
                public const string ShortHand = "CR";
            }

            public class Endangered
            {
                public const string Nb = "Sterkt truet";
                public const string ShortHand = "EN";
            }

            public class Vulnerable
            {
                public const string Nb = "Sårbar";
                public const string ShortHand = "VU";
            }

            public class NearThreatened
            {
                public const string Nb = "Nær truet";
                public const string ShortHand = "NT";
            }

            public class DataDeficient
            {
                public const string Nb = "Datamangel";
                public const string ShortHand = "DD";
            }

            public class Viable
            {
                public const string Nb = "Livskraftig";
                public const string ShortHand = "LC";
            }

            public class NotAppropriate
            {
                public const string Nb = "Ikke egnet";
                public const string ShortHand = "NA";
            }

            public class NotEvalueted
            {
                public const string Nb = "Ikke vurdert";
                public const string ShortHand = "NE";
            }
        }

        public class SearchAndFilter
        {
            public const string ChooseEndangered = "Marker alle truede arter";
            public const string ChooseRedlisted = "Marker alle rødlistearter";
            public const string ResetAllFilters = "Nullstill filtre";
            public const string SearchChangedCategory = "Vis arter med endret kategori fra 2015";
            public const string SearchChooseArea = "Vurderingsområde";
            public const string SearchChooseCategory = "Kategori";
            public const string SearchChooseCriteria = "Kriterier";
            public const string SearchChooseSpeciesGroup = "Artsgruppe";
            public const string SearchFilterSpecies = "Søk art/slekt";
        }
    }
}