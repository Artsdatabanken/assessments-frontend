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

        public static List<string> findSelectedCategories( bool redlisted, bool endangered,
            string[] categoriesSelected) 
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
                    selectedCategories.Add(category);
            else if (endangered) 
                foreach (var category in endangeredList)
                    selectedCategories.Add(category);
            foreach (var s in categoriesSelected)
            {
                if (!selectedCategories.Contains(s))
                {
                    selectedCategories.Add(s);
                }
            }
            //foreach (var entry in categories)
            //    if (entry.Value)
            //        selectedCategories.Add(entry.Key);

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

        public static List<string> findSelectedRegions(Dictionary<string, bool> selectedRegions)
        {
            List<string> regions = new List<string>();
            if (selectedRegions[Constants.Regions.Agder])
            {
                regions.Add(Constants.Regions.VestAgder);
                regions.Add(Constants.Regions.AustAgder);
            }

            if (selectedRegions[Constants.Regions.Innlandet])
            {
                regions.Add(Constants.Regions.Oppland);
                regions.Add(Constants.Regions.Hedmark);
            }

            if (selectedRegions[Constants.Regions.VestfoldTelemark])
            {
                regions.Add(Constants.Regions.Vestfold);
                regions.Add(Constants.Regions.Telemark);
            }

            if (selectedRegions[Constants.Regions.MoreRomsdal])
                regions.Add(Constants.Regions.MoreRomsdal);

            if (selectedRegions[Constants.Regions.Nordland])
                regions.Add(Constants.Regions.Nordland);

            if (selectedRegions[Constants.Regions.Rogaland])
                regions.Add(Constants.Regions.Rogaland);

            if (selectedRegions[Constants.Regions.TromsFinnmark])
            {
                regions.Add(Constants.Regions.Troms);
                regions.Add(Constants.Regions.Finnmark);
            }

            if (selectedRegions[Constants.Regions.Trondelag])
                regions.Add(Constants.Regions.Trondelag);

            if (selectedRegions[Constants.Regions.Vestland])
            {
                regions.Add(Constants.Regions.SognFjordane);
                regions.Add(Constants.Regions.Hordaland);
            }

            if (selectedRegions[Constants.Regions.VikenOslo])
            {
                regions.Add(Constants.Regions.OsloAkershus);
                regions.Add(Constants.Regions.Buskerud);
                regions.Add(Constants.Regions.Ostfold);
            }

            if (selectedRegions[Constants.Regions.Havomraader])
            {
                regions.Add(Constants.Regions.Nordsjoen);
                regions.Add(Constants.Regions.Norskehavet);
                regions.Add(Constants.Regions.Gronlandshavet);
                regions.Add(Constants.Regions.Polhavet);
                regions.Add(Constants.Regions.Barentshavet);
            }
            
            return regions;
        }

        public static List<string> findEuropeanPopProcentages(Dictionary<string, bool> europeanPopulation)
        {
            List<string> selectedPercenteges = new List<string>();
            
            if (europeanPopulation[Constants.EuropeanPopulationPercentages.EuropeanPopLt5]) 
            {
                selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Lt1);
                selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Lt5);
                selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Range1To5);
            }
            if (europeanPopulation[Constants.EuropeanPopulationPercentages.EuropeanPopRange5To25])
                selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Range5To25);
            if (europeanPopulation[Constants.EuropeanPopulationPercentages.EuropeanPopRange25To50])
                selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Range25To50);
            if (europeanPopulation[Constants.EuropeanPopulationPercentages.EuropeanPopGt50])
                selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Gt50);

            return selectedPercenteges;
        }
    }

    public static class Constants
    {
        public const string CacheFolder = "Cache";

        public const string AssessmentsMappingAssembly = "Assessments.Mapping";

        public class EuropeanPopulationPercentages
        {
            public const string EuropeanPopLt5 = "europeanPopLt5";
            public const string EuropeanPopRange5To25 = "europeanPopRange5To25";
            public const string EuropeanPopRange25To50 = "europeanPopRange25To50";
            public const string EuropeanPopGt50 = "europeanPopGt50";
            public const string Lt1 = "< 1 %";
            public const string Lt5 = "< 5 %";
            public const string Gt50 = "> 50 %";
            public const string Range1To5 = "1 - 5 %";
            public const string Range5To25 = "5 - 25 %";
            public const string Range25To50 = "25 - 50 %";
        }

        public class Regions
        {
            public const string Agder = "Agder";
            public const string VestAgder = "Vest-Agder";
            public const string AustAgder = "Aust-Agder";

            public const string Innlandet = "Innlandet";
            public const string Oppland = "Oppland";
            public const string Hedmark = "Hedmark";

            public const string VestfoldTelemark = "Vestfold og Telemark";
            public const string Vestfold = "Vestfold";
            public const string Telemark = "Telemark";

            public const string MoreRomsdal = "Møre og Romsdal";

            public const string Nordland = "Nordland";

            public const string Rogaland = "Rogaland";

            public const string TromsFinnmark = "Troms og Finnmark";
            public const string Troms = "Troms";
            public const string Finnmark = "Finnmark";

            public const string Trondelag = "Trøndelag";

            public const string Vestland = "Vestland";
            public const string SognFjordane = "Sogn og Fjordane";
            public const string Hordaland = "Hordaland";

            public const string VikenOslo = "Viken og Oslo";
            public const string OsloAkershus = "Oslo og Akershus";
            public const string Buskerud = "Buskerud";
            public const string Ostfold = "Østfold";

            public const string Havomraader = "Havområder";
            public const string Nordsjoen = "Nordsjøen";
            public const string Norskehavet = "Norskehavet";
            public const string Gronlandshavet = "Grønlandshavet";
            public const string Polhavet = "Polhavet";
            public const string Barentshavet = "Barentshavet";
        }

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

    public static class FilterViewHelpers
    {
        public static class Filters
        {
            public static string[] AssessmentAreas = new string[] {"Norge", "Svalbard"};
        }
    }
}