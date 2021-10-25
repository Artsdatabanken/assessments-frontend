using Assessments.Mapping.Models.Species;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Helpers
    {
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
                case (true, "ScientificName"):
                    query = query.OrderBy(x => x.ScientificName);
                    break;
                case (true, "PopularName"):
                    query = query
                                .OrderBy(x => string.IsNullOrEmpty(x.PopularName))
                                .ThenBy(x => x.PopularName);
                    break;
                case (true, "Category"):
                    query = query.OrderBy(x => x.Category, new CategoryComparer());
                    break;
                case (true, "SpeciesGroup"):
                    query = query.OrderBy(x => x.SpeciesGroup);
                    break;

                // with search string "name"
                case (false, "ScientificName"):
                    query = query
                        .OrderByDescending(x => x.PopularName.ToLower() == name ||
                        x.ScientificName.ToLower() == name)
                        .ThenBy(x => x.ScientificName);
                    break;
                case (false, "PopularName"):
                    query = query
                        .OrderByDescending(x => x.PopularName.ToLower() == name ||
                        x.ScientificName.ToLower() == name)
                        .ThenBy(x => !string.IsNullOrEmpty(x.PopularName))
                        .ThenBy(x => x.PopularName);
                    break;
                case (false, "Category"):
                    query = query
                        .OrderByDescending(x => x.PopularName.ToLower() == name ||
                        x.ScientificName.ToLower() == name)
                        .ThenBy(x => x.Category, new CategoryComparer());
                    break;
                case (false, "SpeciesGroup"):
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

        public static Dictionary<string, string> getAllTaxonRanks(string[] ranks)
        {
            string[] displayNames = new string[] { "Art", "Underart/varietet" };
            Dictionary<string, string> taxonRanks = new Dictionary<string, string>();
            for (int i = 0; i < ranks.Length; i++)
            {
                taxonRanks.Add(ranks[i], displayNames[i]);
            }
            return taxonRanks;
        }

        public static bool isNotEmpty(string key)
        {
            if(key != null && key != " " && key != "-" && key != "" && key != "Helt ukjent")
        {
                return true;
            }
            return false;
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
        
        public class Filename
        {
            public const string Species2021 = "species-2021.json";

            // filnavn for modeller lagret som "RL2019"
            public const string Species2021Temp = "species-2021-temp.json";

            public const string Species2015 = "species-2015.json";

            public const string Species2006 = "species-2006.json";

            public const string SpeciesExpertCommitteeMembers = "species-experts.csv";
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
