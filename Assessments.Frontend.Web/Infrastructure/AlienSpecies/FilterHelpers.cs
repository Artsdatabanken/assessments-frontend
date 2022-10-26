using Assessments.Frontend.Web.Models;
using System;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class FilterHelpers : IFilter<AlienSpeciesListParameters>
    {
        public string IGetActiveFilters(string filterType, AlienSpeciesListParameters parameters)
        {
            return GetActiveFilters(filterType, parameters);
        }

        public string IGetActiveSelection(AlienSpeciesListParameters parameters)
        {
            return GetActiveSelection(parameters);
        }

        public int IGetActiveSelectionCount(AlienSpeciesListParameters parameters)
        {
            return GetActiveSelectionCount(parameters);
        }

        public string[] IGetActiveSelectionElement(AlienSpeciesListParameters parameters)
        {
            return GetActiveSelectionElement(parameters);
        }

        public string IGetChipText(string filter, Filter.FilterItem[] filterItems)
        {
            return GetChipText(filter, filterItems);
        }

        public static string GetActiveFilters(string filterType, AlienSpeciesListParameters parameters)
        {
            switch (filterType)
            {
                case "Area":
                    if (parameters.Area?.Any() == true)
                        return $"{parameters.Area.Length}";
                    return String.Empty;
                case "Category":
                    if (parameters.Category?.Any() == true)
                        return $"{parameters.Category.Length}";
                    return String.Empty;
                case "TaxonRank":
                    if (parameters.TaxonRank?.Any() == true)
                        return $"{parameters.TaxonRank.Length}";
                    return String.Empty;
                case "ProductionSpecies":
                    if (parameters.ProductionSpecies?.Any() == true)
                        return $"{parameters.ProductionSpecies.Length}";
                    return String.Empty;
                case "SpeciesGroups":
                    if (parameters.SpeciesGroups?.Any() == true)
                    {
                        if (parameters.SpeciesGroups.Contains("Insekter"))
                            return $"{parameters.SpeciesGroups.Length - 1}";
                        return $"{parameters.SpeciesGroups.Length}";
                    }
                    return String.Empty;
                case "Habitats":
                    if (parameters.Habitats?.Any() == true)
                        return $"{parameters.Habitats.Length}";
                    return String.Empty;
                case "Regions":
                    if (parameters.Regions?.Any() == true)
                        return $"{parameters.Regions.Length}";
                    return String.Empty;
                case "WaterRegions":
                    if (parameters.WaterRegions?.Any() == true)
                        return $"{parameters.WaterRegions.Length}";
                    return String.Empty;
                case "Criterias":
                    if (parameters.Criterias?.Any() == true)
                        return $"{parameters.Criterias.Length}";
                    return String.Empty;
                case "Insects":
                    if (Constants.AllInsects.Any(insect => parameters.SpeciesGroups.Contains(insect)))
                    {
                        int count = 0;
                        foreach (var insect in Constants.AllInsects)
                            if (parameters.SpeciesGroups.Contains(insect))
                                count++;
                        return $"{count}";
                    }
                    return String.Empty;
                default:
                    return String.Empty;
            }
        }

        public static string GetActiveSelection(AlienSpeciesListParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.Name))
            {
                return $"{parameters.Name}";
            }
            return String.Empty;
        }

        public static int GetActiveSelectionCount(AlienSpeciesListParameters parameters)
        {
            int count = 0;
            count += parameters.Area.Length;
            count += parameters.Category.Length;
            count += parameters.EstablishmentCategories.Length;
            count += parameters.SpeciesGroups.Length;
            count += parameters.ProductionSpecies.Length;
            count += parameters.TaxonRank.Length;
            count += parameters.Habitats.Length;
            count += parameters.Regions.Length;
            count += parameters.WaterRegions.Length;
            count += parameters.Criterias.Length;

            return count;
        }

        public static string[] GetActiveSelectionElement(AlienSpeciesListParameters parameters)
        {
            var selectionlist = parameters.Area;
            selectionlist = selectionlist.Concat(parameters.Category).ToArray();
            selectionlist = selectionlist.Concat(parameters.ProductionSpecies).ToArray();
            selectionlist = selectionlist.Concat(parameters.SpeciesGroups).ToArray();
            selectionlist = selectionlist.Concat(parameters.TaxonRank).ToArray();
            selectionlist = selectionlist.Concat(parameters.Habitats).ToArray();
            selectionlist = selectionlist.Concat(parameters.Regions).ToArray();
            selectionlist = selectionlist.Concat(parameters.WaterRegions).ToArray();
            selectionlist = selectionlist.Concat(parameters.Criterias).ToArray();
            return selectionlist;
        }

        public static string GetChipText(string filter, Filter.FilterItem[] filterItems)
        {
            for (int i = 0; i < filterItems.Length; i++)
            {
                Filter.FilterItem item = filterItems[i];
                if (item.NameShort == filter)
                {
                    return item.Name;
                }
                else if (item.SubGroup != null)
                {
                    string buttonText = GetChipText(filter, item.SubGroup);
                    if (!string.IsNullOrEmpty(buttonText))
                        return buttonText;
                }
            }
            return String.Empty;
        }

        public static void RemoveAllFilters(AlienSpeciesListParameters parameters)
        {
            parameters = new AlienSpeciesListParameters();
        }

        public class SearchAndFilterNames
        {
            public const string AssessmentArea = "Område";
            public const string Category = "Risikokategori";
            public const string GeographicRiskVariation = "Geografisk variasjon i risiko";
            public const string ClimateChangeRisk = "Betydning av klimaendringer for risiko";
            public const string CategoryChange = "Endring i risikokategori";
            public const string FirstTimeAssessment = "Risikovurdert for første gang";
            public const string ChooseCriteria = "Avgjørende kriterier for risikokategori";
            public const string EstablishmentCategory = "Etableringsklasse i dag";
            public const string ProductionSpecies = "Bruksart";
            public const string ChooseSpeciesGroup = "Artsgrupper";
            public const string TaxonRank = "Taksonomi";
            public const string KnownOrExpectedInRegion = "Regioner med kjent eller forventet forekomst";
            public const string NaturType = "Naturtype";
            public const string WaysOfSpreading = "Spredningsmåter";
            public const string RegionallyAlienSpecies = "Regionalt fremmede arter";
            public const string NonAssessedSpecies = "Ikke risikovurderte arter";

            public const string RemoveFilters = "remove_filters";
            public const string RemoveSearch = "remove_search";
            public const string ResetAllFilters = "Nullstill";
            public const string SearchFilterSpecies = "Søk art/slekt";
        }
    }
}
