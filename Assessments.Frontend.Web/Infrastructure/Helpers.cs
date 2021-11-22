using Assessments.Mapping.Models.Species;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Helpers
    {
        private static Dictionary<string, string> _ranks = new Dictionary<string, string>
        {
            { "Species", "Art" },
            { "SubSpecies", "Underart" },
            { "Variety", "Varietet" }
        };

        public static string FormatNumeric(string value)
        {
            if (int.TryParse(value, out int result))
            {
                if (value.Length < 5)
                    return result.ToString();
                return result.ToString("### ### ###");
            }
            return value;
        }

        public static string[] findSelectedCategories( bool redlisted, bool endangered,
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
            return selectedCategories.ToArray();
        }

        public static string[] getAllSpeciesGroups(Dictionary<string, Dictionary<string, string>> speciesGroups)
        {
            var insectArray = Constants.AllInsects;
            List<string> allSpecies = new List<string>();
            foreach (var species in speciesGroups)
                if (!insectArray.Contains(species.Key))
                    allSpecies.Add(species.Key);
            allSpecies.Add("Insekter");
            return allSpecies.OrderBy(x => x).ToArray();
        }

        public static string[] getSelectedSpeciesGroups(List<string> species)
        {
            if (species.Contains("Insekter"))
                foreach (var insect in Constants.AllInsects)
                    if (!species.Contains(insect))
                        species.Add(insect);
            
            return species.ToArray();
        }

        public static Dictionary<string, string> getRegionsDict()
        {
            var regionNames = SortedRegions().ToArray();

            Dictionary<string, string> allRegions = new Dictionary<string, string>();
            for (int i = 0; i < regionNames.Length; i++)
            {
                allRegions.Add($"{i}", regionNames[i]);
            }
            return allRegions;
        }

        public static IQueryable<SpeciesAssessment2021> sortResults(IQueryable<SpeciesAssessment2021> query, string name, string sortBy)
        {
            switch ((string.IsNullOrEmpty(name), sortBy))
            {
                // without search string "name"
                case (true, nameof(SpeciesAssessment2021.ScientificName)):
                    query = query.OrderBy(x => x.ScientificName);
                    break;
                case (true, nameof(SpeciesAssessment2021.PopularName)):
                    query = query
                                .OrderBy(x => string.IsNullOrEmpty(x.PopularName))
                                .ThenBy(x => x.PopularName);
                    break;
                case (true, nameof(SpeciesAssessment2021.Category)):
                    query = query.OrderBy(x => x.Category, new CategoryComparer());
                    break;
                case (true, nameof(SpeciesAssessment2021.SpeciesGroup)):
                    query = query.OrderBy(x => x.SpeciesGroup);
                    break;

                // with search string "name"
                case (false, nameof(SpeciesAssessment2021.ScientificName)):
                    query = query
                        .OrderByDescending(x => x.PopularName.ToLower() == name ||
                        x.ScientificName.ToLower() == name)
                        .ThenByDescending(x => x.VurdertVitenskapeligNavnHierarki.ToLower().Contains('/' + name + '/'))
                        .ThenBy(x => x.ScientificName);
                    break;
                case (false, nameof(SpeciesAssessment2021.PopularName)):
                    query = query
                        .OrderByDescending(x => x.PopularName.ToLower() == name ||
                        x.ScientificName.ToLower() == name)
                        .ThenBy(x => !string.IsNullOrEmpty(x.PopularName))
                        .ThenBy(x => x.PopularName);
                    break;
                case (false, nameof(SpeciesAssessment2021.Category)):
                    query = query
                        .OrderByDescending(x => x.PopularName.ToLower() == name ||
                        x.ScientificName.ToLower() == name)
                        .ThenBy(x => x.Category, new CategoryComparer());
                    break;
                case (false, nameof(SpeciesAssessment2021.SpeciesGroup)):
                    query = query
                        .OrderByDescending(x => x.PopularName.ToLower() == name ||
                        x.ScientificName.ToLower() == name)
                        .ThenBy(x => x.SpeciesGroup);
                    break;
                case (false, null):
                    query = query
                        .OrderByDescending(x => x.PopularName.ToLower() == name ||
                        x.ScientificName.ToLower() == name);
                    break;
                default:
                    query = query.OrderBy(x => x.ScientificName);
                    break;
            }
            return query;
        }

        public static string[] findSelectedRegions(string[] selectedRegions, Dictionary<string, string> allRegions)
        {
            List<string> regions = new List<string>();
            foreach (var region in selectedRegions)
            {
                regions.Add(allRegions[region]);
            }
            return regions.ToArray();
        }

        public static IQueryable<SpeciesAssessment2021> GetQueryByName(IQueryable<SpeciesAssessment2021> query, string name)
        {
            var speciesHitScientificNames = query.Where(x => x.PopularName.ToLower().Contains(name)).Select(x => x.ScientificName).ToArray();

            return query.Where(x =>
                x.ScientificName.ToLower().Contains(name) ||                            // Match on scientific name.
                speciesHitScientificNames.Any(hit => x.ScientificName.Contains(hit)) || // Search on species also finds supspecies.
                x.PopularName.ToLower().Contains(name) ||                               // Match on popular name.
                x.VurdertVitenskapeligNavnHierarki.ToLower().Contains(name) ||          // Match on taxonomic path.
                x.SpeciesGroup.ToLower().Contains(name));                               // Match on species group.
        }

        /// <summary>
        ///  Sortert liste med navn på regioner (etter gamle fylkesnummer)
        /// </summary>
        public static List<string> SortedRegions() => new() { "Østfold", "Oslo og Akershus", "Hedmark", "Oppland", "Buskerud", "Vestfold", "Telemark", "Aust-Agder", "Vest-Agder", "Rogaland", "Hordaland", "Sogn og Fjordane", "Møre og Romsdal", "Trøndelag", "Nordland", "Troms", "Finnmark", "Svalbard", "Jan Mayen", "Nordsjøen", "Norskehavet", "Barentshavet sør", "Barentshavet nord og Polhavet", "Grønlandshavet" };
        
        public static string[] findEuropeanPopProcentages(string[] europeanPopulation)
        {
            List<string> selectedPercenteges = new List<string>();

            foreach (var item in europeanPopulation)
            {
                if (item == Constants.EuropeanPopulationPercentages.EuropeanPopLt5)
                {
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Lt1);
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Lt5);
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Range1To5);
                }
                else if (item == Constants.EuropeanPopulationPercentages.EuropeanPopRange5To25)
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Range5To25);
                else if (item == Constants.EuropeanPopulationPercentages.EuropeanPopRange25To50)
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Range25To50);
                else if (item == Constants.EuropeanPopulationPercentages.EuropeanPopGt50)
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Gt50);
            }
            return selectedPercenteges.ToArray();
        }

        public static Dictionary<string, string> getAllTaxonRanks()
        {
            return _ranks;
        }

        public static bool isNotEmpty(string key)
        {
            if (key != null && key != " " && key != "-" && key != "" && key != "Helt ukjent")
            {
                return true;
            }
            return false;
        }

        public static string findDegrees(string category,bool parenthesis)
        {
            string text = "";
            if (category.Length >2)
            {
                text = "nedgradert";
            }
            if (parenthesis && category.Length > 2)
            {
                return "(" + text + ")";
            }

            return text;
        }

        public static string getScientificNameElement(string scientificName)
        {
            scientificName = "<i>"+scientificName+"</i>";
            scientificName = scientificName.Replace("×", "</i>×<i>");
            scientificName = scientificName.Replace("aff.", "</i>aff.<i>");
            scientificName = scientificName.Replace("agg.", "</i>agg.<i>");
            scientificName = scientificName.Replace("coll.", "</i>coll.<i>");
            scientificName = scientificName.Replace("n.", "</i>n.<i>");
            scientificName = scientificName.Replace("subsp.", "</i>subsp.<i>");
            scientificName = scientificName.Replace("var.", "</i>var.<i>");
            scientificName = scientificName.Replace(" '", "</i> '");
            scientificName = scientificName.Replace("' ", "'<i> ");
            scientificName = scientificName.Replace("<i></i>", "");
            return scientificName;
        }
    }

    public static class Constants
    {
        public const string CacheFolder = "Cache";

        public const string AssessmentsMappingAssembly = "Assessments.Mapping";

        public static readonly Dictionary<string, string> AllAreas = new Dictionary<string, string>
        {
            {"Norge", "N"},
            {"Svalbard", "S"}
        };

        public static readonly Dictionary<string, string> AllCriterias = new Dictionary<string, string>
        {
            {"A", "populasjonsreduksjon"},
            {"B", "lite areal"},
            {"C", "liten populasjon"},
            {"D", "svært liten populasjon eller forekomst"}
        };

        public static readonly Dictionary<string, string> AllEuropeanPopulationPercentages = new Dictionary<string, string>
        {
            {Constants.EuropeanPopulationPercentages.EuropeanPopLt5, "< 5 %"},
            {Constants.EuropeanPopulationPercentages.EuropeanPopRange5To25, "5 - 25 %"},
            {Constants.EuropeanPopulationPercentages.EuropeanPopRange25To50, "25 - 50 %"},
            {Constants.EuropeanPopulationPercentages.EuropeanPopGt50, "> 50 %"}
        };

        public static readonly string[] AllInsects = new string[]
        {
            "Biller",
            "Døgnfluer",
            "Kakerlakker",
            "Kamelhalsfluer",
            "Mudderfluer",
            "Nebbfluer",
            "Nebbmunner",
            "Nettvinger",
            "Rettvinger",
            "Saksedyr",
            "Sommerfugler",
            "Steinfluer",
            "Tovinger",
            "Vepser",
            "Vårfluer",
            "Øyenstikkere"
        };
        
        public class EuropeanPopulationPercentages
        {
            public const string EuropeanPopLt5 = "Lt5";
            public const string EuropeanPopRange5To25 = "Fr5To25";
            public const string EuropeanPopRange25To50 = "Fr25To50";
            public const string EuropeanPopGt50 = "Gt50";
            public const string Lt1 = "< 1 %";
            public const string Lt5 = "< 5 %";
            public const string Gt50 = "> 50 %";
            public const string Range1To5 = "1 - 5 %";
            public const string Range5To25 = "5 - 25 %";
            public const string Range25To50 = "25 - 50 %";
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
            public const string ResetAllFilters = "Nullstill";
            public const string SearchChangedCategory = "Vis arter med endret kategori fra 2015";
            public const string SearchChooseArea = "Vurderingsområde";
            public const string SearchChooseCategory = "Kategori";
            public const string SearchChooseCriteria = "Kriterier";
            public const string SearchChooseSpeciesGroup = "Artsgruppe";
            public const string SearchFilterSpecies = "Søk art/slekt";
            public const string SearchFilterTaxonRank = "Taksonomisk nivå";
        }

        public static class TaxonCategoriesEn
        {
            public static int Unknown = 0;
            public static int Kingdom = 1;
            public static int SubKingdom = 2;
            public static int Phylum = 3;
            public static int SubPhylum = 4;
            public static int SuperClass = 5;
            public static int Class = 6;
            public static int SubClass = 7;
            public static int InfraClass = 8;
            public static int Cohort = 9;
            public static int SuperOrder = 10;
            public static int Order = 11;
            public static int SubOrder = 12;
            public static int InfraOrder = 13;
            public static int SuperFamily = 14;
            public static int Family = 15;
            public static int SubFamily = 16;
            public static int Tribe = 17;
            public static int SubTribe = 18;
            public static int Genus = 19;
            public static int SubGenus = 20;
            public static int Section = 21;
            public static int Species = 22;
            public static int SubSpecies = 23;
            public static int Variety = 24;
            public static int Form = 25;
        };

        public static Dictionary<string, string> TaxonCategoriesNbToEn = new Dictionary<string, string>(){
            { "Unknown", "Unknown" },
            { "Rike", "Kingdom" },
            { "SubKingdom", "SubKingdom" },
            { "Rekke", "Phylum" },
            { "Underrekke", "SubPhylum" },
            { "SuperClass", "SuperClass" },
            { "Klasse", "Class" },
            { "SubClass", "SubClass" },
            { "InfraClass", "InfraClass" },
            { "Cohort", "Cohort" },
            { "SuperOrder", "SuperOrder" },
            { "Orden", "Order" },
            { "SubOrder", "SubOrder" },
            { "InfraOrder", "InfraOrder" },
            { "SuperFamily", "SuperFamily" },
            { "Familie", "Family" },
            { "SubFamily", "SubFamily" },
            { "Tribe", "Tribe" },
            { "SubTribe", "SubTribe" },
            { "Slekt", "Genus" },
            { "SubGenus", "SubGenus" },
            { "Section", "Section" },
            { "Art", "Species" },
            { "Underart", "SubSpecies" },
            { "Varietet", "Variety" },
            { "Form", "Form" }
        };
    }

    public class CategoryComparer : IComparer<string>
    {
        private string[] categories = new string[]
        {
                    "RE", "CR", "EN", "VU", "NT", "DD", "LC", "NA", "NE"
        };
        public int Compare(string x, string y)
        {
            if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
                return 0;

            return Array.IndexOf(categories, x.Substring(0, 2)) - Array.IndexOf(categories, y.Substring(0, 2));
        }
    }
}
