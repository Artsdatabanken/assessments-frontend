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
                case nameof(parameters.Area):
                    if (parameters.Area?.Any() == true)
                        return $"{parameters.Area.Length}";
                    return String.Empty;
                case nameof(parameters.Category):
                    if (parameters.Category?.Any() == true)
                        return $"{parameters.Category.Length}";
                    return String.Empty;
                case nameof(parameters.EcologicalEffect):
                    if (parameters.EcologicalEffect?.Any() == true)
                        return $"{parameters.EcologicalEffect.Length}";
                    return String.Empty;
                case nameof(parameters.InvasionPotential):
                    if (parameters.InvasionPotential?.Any() == true)
                        return $"{parameters.InvasionPotential.Length}";
                    return String.Empty;
                case nameof(parameters.CategoryChanged):
                    if (parameters.CategoryChanged?.Any() == true)
                        return $"{parameters.CategoryChanged.Length}";
                    return String.Empty;
                case nameof(parameters.DecisiveCriterias):
                    if (parameters.DecisiveCriterias?.Any() == true)
                        return $"{parameters.DecisiveCriterias.Length}";
                    return String.Empty;
                case nameof(parameters.SpeciesStatus):
                    if (parameters.SpeciesStatus?.Any() == true)
                        return $"{parameters.SpeciesStatus.Length}";
                    return String.Empty;
                case nameof(parameters.TaxonRank):
                    if (parameters.TaxonRank?.Any() == true)
                        return $"{parameters.TaxonRank.Length}";
                    return String.Empty;
                case nameof(parameters.ProductionSpecies):
                    if (parameters.ProductionSpecies?.Any() == true)
                        return $"{parameters.ProductionSpecies.Length}";
                    return String.Empty;
                case nameof(parameters.SpeciesGroups):
                    if (parameters.SpeciesGroups?.Any() == true)
                    {
                        var count = parameters.SpeciesGroups.Length;
                        if (parameters.SpeciesGroups.Contains("sin"))
                            count--;
                        if (parameters.SpeciesGroups.Contains(nameof(parameters.SpeciesGroups)))
                            count--;
                        return $"{count}";
                    }
                    return String.Empty;
                case nameof(parameters.Habitats):
                    if (parameters.Habitats?.Any() == true)
                        return $"{parameters.Habitats.Length}";
                    return String.Empty;
                case nameof(parameters.Regions):
                    if (parameters.Regions?.Any() == true)
                        return $"{parameters.Regions.Length}";
                    return String.Empty;
                case nameof(parameters.WaterRegions):
                    if (parameters.WaterRegions?.Any() == true)
                        return $"{parameters.WaterRegions.Length}";
                    return String.Empty;
                case nameof(parameters.Criterias):
                    if (parameters.Criterias?.Any() == true)
                        return $"{parameters.Criterias.Length}";
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
            count += parameters.EcologicalEffect.Length;
            count += parameters.InvasionPotential.Length;
            count += parameters.CategoryChanged.Length;
            count += parameters.DecisiveCriterias.Length;
            count += parameters.SpeciesStatus.Length;
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
            selectionlist = selectionlist.Concat(parameters.EcologicalEffect).ToArray();
            selectionlist = selectionlist.Concat(parameters.InvasionPotential).ToArray();
            selectionlist = selectionlist.Concat(parameters.CategoryChanged).ToArray();
            selectionlist = selectionlist.Concat(parameters.DecisiveCriterias).ToArray();
            selectionlist = selectionlist.Concat(parameters.SpeciesStatus).ToArray();
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
                    string buttonText = GetChipText(filter, item.SubGroup.Filters);
                    if (!string.IsNullOrEmpty(buttonText))
                        return buttonText;
                }
            }
            return String.Empty;
        }

        public class SearchAndFilterNames
        {
            public const string AssessmentArea = "Område";
            public const string Category = "Risikokategori";
            public const string EcologicalEffect = "Økologisk effekt (risikomatrisens y-akse)";
            public const string InvasionPotential = "Invasjonspotensial (risikomatrisens x-akse)";
            public const string CategoryChanged = "Endring i risikokategori";
            public const string DecisiveCriteria = "Avgjørende kriterier for kategori";
            public const string GeographicRiskVariation = "Geografisk variasjon i risiko";
            public const string ClimateChangeRisk = "Betydning av klimaendringer for risiko";
            public const string FirstTimeAssessment = "Risikovurdert for første gang";
            public const string ChooseCriteria = "Avgjørende kriterier for risikokategori";
            public const string EstablishmentCategory = "Etableringsklasse i dag";
            public const string ProductionSpecies = "Bruksart";
            public const string SpeciesGroup = "Artsgrupper";
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
