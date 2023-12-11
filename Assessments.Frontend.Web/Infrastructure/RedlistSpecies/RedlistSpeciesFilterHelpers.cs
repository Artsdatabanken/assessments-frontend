using Assessments.Frontend.Web.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Linq;
using static Assessments.Frontend.Web.Infrastructure.Constants;
using static Assessments.Frontend.Web.Infrastructure.FilterHelpers;

namespace Assessments.Frontend.Web.Infrastructure.RedlistSpecies
{
    public static class RedlistSpeciesFilterHelpers
    {
        public static string GetActiveFilters(string filterType, RL2021ViewModel Model)
        {
            switch (filterType)
            {
                case "Area":
                    if (Model.Area?.Any() == true)
                        return $"{Model.Area.Length}";
                    return string.Empty;
                case "Category":
                    if (Model.Category?.Any() == true)
                        return $"{Model.Category.Length}";
                    return string.Empty;
                case "TaxonRank":
                    if (Model.TaxonRank?.Any() == true)
                        return $"{Model.TaxonRank.Length}";
                    return string.Empty;
                case "SpeciesGroups":
                    {
                        var count = Model.SpeciesGroups.Length;
                        if (Model.SpeciesGroups.Contains("Insects"))
                            count--;
                        if (Model.SpeciesGroups.Contains(nameof(Model.SpeciesGroups)))
                            count--;
                        return $"{count}";
                    }
                case "Habitats":
                    if (Model.Habitats?.Any() == true)
                        return $"{Model.Habitats.Length}";
                    return string.Empty;
                case "Regions":
                    if (Model.Regions?.Any() == true)
                        return $"{Model.Regions.Length}";
                    return string.Empty;
                case "EuroPop":
                    if (Model.EuroPop?.Any() == true)
                        return $"{Model.EuroPop.Length}";
                    return string.Empty;
                case "Criterias":
                    if (Model.Criterias?.Any() == true)
                        return $"{Model.Criterias.Length}";
                    return string.Empty;
                case "PresumedExtinct":
                    if (Model.PresumedExtinct == true)
                        return $"1";
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }

        public static string GetChipText(string filter, FilterItem[] filterItems)
        {
            for (int i = 0; i < filterItems.Length; i++)
            {
                FilterItem item = filterItems[i];
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

        public static string GetActiveSelection(RL2021ViewModel Model)
        {
            if (!string.IsNullOrEmpty(Model.Name))
            {
                return $"{Model.Name}";
            }
            return string.Empty;
        }

        public static int GetActiveSelectionCount(RL2021ViewModel Model)
        {
            int count = 0;
            count += Model.Area.Length;
            count += Model.Category.Length;
            count += Model.SpeciesGroups.Length;
            count += Model.TaxonRank.Length;
            count += Model.Habitats.Length;
            count += Model.Regions.Length;
            count += Model.EuroPop.Length;
            count += Model.Criterias.Length;
            if (Model.PresumedExtinct)
                count++;

            return count;
        }

        public static string[] GetActiveSelectionElement(RL2021ViewModel Model)
        {
            var selectionlist = Model.Area;
            selectionlist = selectionlist.Concat(Model.Category).ToArray();
            selectionlist = selectionlist.Concat(Model.SpeciesGroups).ToArray();
            selectionlist = selectionlist.Concat(Model.TaxonRank).ToArray();
            selectionlist = selectionlist.Concat(Model.Habitats).ToArray();
            selectionlist = selectionlist.Concat(Model.Regions).ToArray();
            selectionlist = selectionlist.Concat(Model.EuroPop).ToArray();
            selectionlist = selectionlist.Concat(Model.Criterias).ToArray();
            if (Model.PresumedExtinct)
            {
                string[] PresumedExtinct = new string[] { "Antatt utd�dd" };
                selectionlist = selectionlist.Concat(PresumedExtinct).ToArray();
            }
            return selectionlist;
        }

        public static string[] GetActiveSelectionElement(AlienSpeciesListParameters parameters)
        {
            var selectionlist = parameters.Area;
            selectionlist = selectionlist.Concat(parameters.Category).ToArray();
            selectionlist = selectionlist.Concat(parameters.EcologicalEffect).ToArray();
            selectionlist = selectionlist.Concat(parameters.Environment).ToArray();
            selectionlist = selectionlist.Concat(parameters.NatureTypes).ToArray();
            selectionlist = selectionlist.Concat(parameters.InvasionPotential).ToArray();
            selectionlist = selectionlist.Concat(parameters.CategoryChanged).ToArray();
            selectionlist = selectionlist.Concat(parameters.DecisiveCriterias).ToArray();
            selectionlist = selectionlist.Concat(parameters.SpeciesStatus).ToArray();
            selectionlist = selectionlist.Concat(parameters.NotAssessed).ToArray();
            selectionlist = selectionlist.Concat(parameters.ProductionSpecies).ToArray();
            selectionlist = selectionlist.Concat(parameters.SpeciesGroups).ToArray();
            selectionlist = selectionlist.Concat(parameters.SpreadWays).ToArray();
            selectionlist = selectionlist.Concat(parameters.TaxonRank).ToArray();
            selectionlist = selectionlist.Concat(parameters.Habitats).ToArray();
            selectionlist = selectionlist.Concat(parameters.RegionallyAlien).ToArray();
            selectionlist = selectionlist.Concat(parameters.Regions).ToArray();
            selectionlist = selectionlist.Concat(parameters.Criterias).ToArray();
            selectionlist = selectionlist.Concat(parameters.GeographicVariations).ToArray();
            selectionlist = selectionlist.Concat(parameters.ClimateEffects).ToArray();
            return selectionlist;
        }
    }
}
