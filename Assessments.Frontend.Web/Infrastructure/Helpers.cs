using Assessments.Frontend.Web.Models;
using Assessments.Mapping.RedlistSpecies;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Helpers
    {
        private static readonly Dictionary<string, string> _ranks = new()
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

        public static string[] FindSelectedRedlistSpeciesCategories(bool redlisted, bool endangered,
            string[] categoriesSelected)
        {
            List<string> selectedCategories = new();

            List<string> redlist = new()
            {
                Constants.SpeciesCategories.Extinct.ShortHand,
                Constants.SpeciesCategories.CriticallyEndangered.ShortHand,
                Constants.SpeciesCategories.Endangered.ShortHand,
                Constants.SpeciesCategories.Vulnerable.ShortHand,
                Constants.SpeciesCategories.NearThreatened.ShortHand,
                Constants.SpeciesCategories.DataDeficient.ShortHand
            };

            List<string> endangeredList = new()
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

        public static string[] GetAllSpeciesGroups(Dictionary<string, Dictionary<string, string>> speciesGroups)
        {
            var insectArray = Constants.AllInsects;
            List<string> allSpecies = new();
            foreach (var species in speciesGroups)
                if (!insectArray.Contains(species.Key))
                    allSpecies.Add(species.Key);
            allSpecies.Add("Insekter");
            return allSpecies.OrderBy(x => x).ToArray();
        }

        public static string[] GetSelectedSpeciesGroups(List<string> species)
        {
            if (species.Contains("Insekter"))
                foreach (var insect in Constants.AllInsects)
                    if (!species.Contains(insect))
                        species.Add(insect);

            return species.ToArray();
        }

        public static Dictionary<string, string> GetRegionsDict()
        {
            var regionNames = SortedRegions().ToArray();

            Dictionary<string, string> allRegions = new();
            for (int i = 0; i < regionNames.Length; i++)
            {
                allRegions.Add($"{i}", regionNames[i]);
            }
            return allRegions;
        }

        public static NameValueCollection RemoveFiltersFromQuery(NameValueCollection queryParams)
        {
            queryParams.Remove(nameof(RL2021ViewModel.Area));
            queryParams.Remove(nameof(RL2021ViewModel.Category));
            queryParams.Remove(nameof(RL2021ViewModel.Criterias));
            queryParams.Remove(nameof(RL2021ViewModel.EuroPop));
            queryParams.Remove(nameof(RL2021ViewModel.Regions));
            queryParams.Remove(nameof(RL2021ViewModel.Habitats));
            queryParams.Remove(nameof(RL2021ViewModel.SpeciesGroups));
            queryParams.Remove(nameof(RL2021ViewModel.TaxonRank));
            queryParams.Remove(nameof(RL2021ViewModel.Redlisted));
            queryParams.Remove(nameof(RL2021ViewModel.Endangered));
            queryParams.Remove(nameof(RL2021ViewModel.PresumedExtinct));
            queryParams.Remove(Constants.SearchAndFilter.RemoveFilters);

            return queryParams;
        }

        public static IQueryable<SpeciesAssessment2021> SortResults(IQueryable<SpeciesAssessment2021> query, string name, string sortBy)
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
                        .OrderBy(x => string.IsNullOrEmpty(x.PopularName))
                        .ThenByDescending(x => x.PopularName.ToLower() == name ||
                        x.ScientificName.ToLower() == name)
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

        public static string[] FindSelectedRegions(string[] selectedRegions, Dictionary<string, string> allRegions)
        {
            List<string> regions = new();
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

        public static string[] FindEuropeanPopProcentages(string[] europeanPopulation)
        {
            List<string> selectedPercenteges = new();

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

        public static Dictionary<string, string> GetAllTaxonRanks()
        {
            return _ranks;
        }

        public static bool IsNotEmpty(string key)
        {
            if (key != null && key != " " && key != "-" && key != "" && key != "Helt ukjent")
            {
                return true;
            }
            return false;
        }

        public static string FindDegrees(string category, bool parenthesis)
        {
            string text = "";
            if (category.Length > 2)
            {
                text = "nedgradert";
            }
            if (parenthesis && category.Length > 2)
            {
                return "(" + text + ")";
            }

            return text;
        }

        public static string GetScientificNameElement(string scientificName)
        {
            scientificName = "<i>" + scientificName + "</i>";
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

        public static string GetPublishedDate(int assesmentyear, int yearPreviousAssessment, string firstPublished)
        {
            firstPublished = assesmentyear == 2010 ? yearPreviousAssessment.ToString() : firstPublished;
            return firstPublished;
        }

        public static string GetRevisionDate(DateTime RevisionDate, string firspublished)
        {
            if (RevisionDate.Date.ToShortDateString() != firspublished && RevisionDate != default)
            {
                return RevisionDate.Date.ToShortDateString();
            }
            return string.Empty;
        }

        public static string FixSpeciesLevel(string replacestring, string rang)
        {
            var subSpecies = "Underart";
            var species = "Art";
            var variety = "Varietet";

            if (rang == "SubSpecies" || rang == subSpecies)
            {
                replacestring = replacestring.Replace("{art}", subSpecies.ToLower());
                replacestring = replacestring.Replace("{Art}", subSpecies);
            }
            else if (rang == "Variety" || rang == variety)
            {
                replacestring = replacestring.Replace("{art}", variety.ToLower());
                replacestring = replacestring.Replace("{Art}", variety);
            }
            else
            {
                replacestring = replacestring.Replace("{art}", species.ToLower());
                replacestring = replacestring.Replace("{Art}", species);
            }
            return replacestring;
        }
        public static string FixSpeciesLevel(string replaceString, int rank)
        {
            var stringRank = rank switch
            {
                22 => "Art",
                23 => "Underart",
                24 => "Varietet",
                _ => "Art"
            };
            return Helpers.FixSpeciesLevel(replaceString, stringRank);
        }
    }

    public class CategoryComparer : IComparer<string>
    {
        private readonly string[] categories = new string[]
        {
                    "RE", "CR", "EN", "VU", "NT", "DD", "LC", "NA", "NE"
        };
        public int Compare(string x, string y)
        {
            if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
                return 0;

            return Array.IndexOf(categories, x[..2]) - Array.IndexOf(categories, y[..2]);
        }
    }
}
