using Assessments.Frontend.Web.Models;
using System;
using System.Linq;
using static Assessments.Frontend.Web.Infrastructure.Constants;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Filter
    {
        public class FilterAndMetaData
        {
            public FilterItem[] Filters { get; set; }

            public string FilterDescription { get; set; }
        }

        public class FilterItem
        {
            public string Description { get; set; }

            public string FilterHelpText { get; set; }

            public string InfoUrl { get; set; }

            public string ImageUrl { get; set; }

            public string Mapping { get; set; }

            public string Name { get; set; }

            public string NameShort { get; set; }

            public FilterAndMetaData SubGroup { get; set; }
        }

        public static string GetActiveFilters(string filterType, RL2021ViewModel Model)
        {
            switch (filterType)
            {
                case "Area":
                    if (Model.Area?.Any() == true)
                        return $"{Model.Area.Length}";
                    return String.Empty;
                case "Category":
                    if (Model.Category?.Any() == true)
                        return $"{Model.Category.Length}";
                    return String.Empty;
                case "TaxonRank":
                    if (Model.TaxonRank?.Any() == true)
                        return $"{Model.TaxonRank.Length}";
                    return String.Empty;
                case "SpeciesGroups":
                    if (Model.SpeciesGroups?.Any() == true)
                    {
                        if (Model.SpeciesGroups.Contains("Insekter"))
                            return $"{Model.SpeciesGroups.Length - 1}";
                        return $"{Model.SpeciesGroups.Length}";
                    }
                    return String.Empty;
                case "Habitats":
                    if (Model.Habitats?.Any() == true)
                        return $"{Model.Habitats.Length}";
                    return String.Empty;
                case "Regions":
                    if (Model.Regions?.Any() == true)
                        return $"{Model.Regions.Length}";
                    return String.Empty;
                case "EuroPop":
                    if (Model.EuroPop?.Any() == true)
                        return $"{Model.EuroPop.Length}";
                    return String.Empty;
                case "Criterias":
                    if (Model.Criterias?.Any() == true)
                        return $"{Model.Criterias.Length}";
                    return String.Empty;
                case "PresumedExtinct":
                    if (Model.PresumedExtinct == true)
                        return $"1";
                    return String.Empty;
                case "Insects":
                    if (AllInsects.Any(insect => Model.SpeciesGroups.Contains(insect)))
                    {
                        int count = 0;
                        foreach (var insect in AllInsects)
                            if (Model.SpeciesGroups.Contains(insect))
                                count++;
                        return $"{count}";
                    }
                    return String.Empty;
                default:
                    return String.Empty;
            }
        }

        public static string GetActiveSelection(RL2021ViewModel Model)
        {
            if (!string.IsNullOrEmpty(Model.Name))
            {
                return $"{Model.Name}";
            }
            return String.Empty;
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
                string[] PresumedExtinct = new string[] { "Antatt utdødd" };
                selectionlist = selectionlist.Concat(PresumedExtinct).ToArray();
            }
            return selectionlist;
        }
    }
}