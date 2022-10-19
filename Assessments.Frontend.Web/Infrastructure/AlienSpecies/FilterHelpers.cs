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
            count += parameters.SpeciesGroups.Length;
            count += parameters.TaxonRank.Length;
            count += parameters.Habitats.Length;
            count += parameters.Regions.Length;
            count += parameters.Criterias.Length;

            return count;
        }

        public static string[] GetActiveSelectionElement(AlienSpeciesListParameters parameters)
        {
            var selectionlist = parameters.Area;
            selectionlist = selectionlist.Concat(parameters.Category).ToArray();
            selectionlist = selectionlist.Concat(parameters.SpeciesGroups).ToArray();
            selectionlist = selectionlist.Concat(parameters.TaxonRank).ToArray();
            selectionlist = selectionlist.Concat(parameters.Habitats).ToArray();
            selectionlist = selectionlist.Concat(parameters.Regions).ToArray();
            selectionlist = selectionlist.Concat(parameters.Criterias).ToArray();
            return selectionlist;
        }
    }
}
