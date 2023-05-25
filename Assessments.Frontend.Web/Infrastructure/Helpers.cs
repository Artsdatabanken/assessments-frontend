using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Mapping.RedlistSpecies;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
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
                    query = query.OrderBy(x => x.Category, new RedlistCategoryComparer());
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
                        .ThenBy(x => x.Category, new RedlistCategoryComparer());
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
            // Searching for a specific taxonomic rank
            var rankIndexAt = name.IndexOf('(');
            var rankIndexEnd = name.IndexOf(')');
            var rank = String.Empty;
            if (rankIndexAt > 0 && rankIndexEnd > 0)
            {
                rank = name.Substring(rankIndexAt + 1, rankIndexEnd - 1 - rankIndexAt);
                if (rank.Length > 2)
                {
                    rank = rank[0].ToString().ToUpperInvariant() + rank[1..].ToLowerInvariant();
                }
                name = name[..rankIndexAt].Trim().ToLowerInvariant();
            }

            // If taxonomic rank is not valid, the normal search will be used instead
            if (!string.IsNullOrEmpty(rank))
            {
                if (Constants.TaxonCategoriesNbToEn.TryGetValue(rank, out string rankValue))
                {
                    return query.Where(x => x.VurdertVitenskapeligNavnHierarki.Replace('/', ' ').Split().Reverse().Skip(1).ToList().Any(y => y.ToLowerInvariant() == name));
                }
            }

            // Normal search
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

        public static string removeLineBreaksForMobile(string text)
        {
            return text.Replace("<br/>", "");
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
            string text = string.Empty;
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

        public static string FormatScientificNameElement(string scientificName)
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
            var form = "Form";

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
            else if (rang == form)
            {
                replacestring = replacestring.Replace("{art}", form.ToLower());
                replacestring = replacestring.Replace("{Art}", form);
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
                25 => "Form",
                _ => "Art"
            };
            return Helpers.FixSpeciesLevel(replaceString, stringRank);
        }
        public static string FixSpeciesLevel(string replaceString, AlienSpeciesAssessment2023ScientificNameRank rank)
        {
            var stringRank = rank switch
            {
                AlienSpeciesAssessment2023ScientificNameRank.Species => "Art",
                AlienSpeciesAssessment2023ScientificNameRank.SubSpecies => "Underart",
                AlienSpeciesAssessment2023ScientificNameRank.Variety => "Varietet",
                AlienSpeciesAssessment2023ScientificNameRank.Form => "Form",
                _ => "Art"
            };
            return Helpers.FixSpeciesLevel(replaceString, stringRank);
        }

        public static string GetBarChartHeight(int max, int currect)
        {
            var value = (float)(currect * 100.0 / max);
            return value.ToString("F", CultureInfo.InvariantCulture);
        }

        public static int GetBarChartTotal(List<BarChart.BarChartData> data)
        {
            return data.Sum(x => x.Count);
        }

        public static int GetBarChartHighRisk(List<BarChart.BarChartData> data)
        {
            return data.Where(x => x.NameShort == AlienSpeciesAssessment2023Category.HI.ToString() || x.NameShort == AlienSpeciesAssessment2023Category.SE.ToString()).Sum(x => x.Count);
        }
    }

    public class RedlistCategoryComparer : IComparer<string>
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

    public class AlienSpeciesCategoryComparer : IComparer<string>
    {
        private readonly List<string> listOrder = new()
        {
            AlienSpeciesAssessment2023Category.NR.ToString(),
            AlienSpeciesAssessment2023Category.LO.ToString(),
            AlienSpeciesAssessment2023Category.PH.ToString(),
            AlienSpeciesAssessment2023Category.HI.ToString(),
            AlienSpeciesAssessment2023Category.SE.ToString()
        };

        public int Compare(string x, string y)
        {
            if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
                return 0;

            return listOrder.IndexOf(x) - listOrder.IndexOf(y);
        }
    }
}
