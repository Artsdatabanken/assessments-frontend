namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class AlienSpeciesHelpers
    {
        public static Filter.FilterItem GetSpeciesGroup(Filter.FilterItem[] speciesGroups, string speciesGroupName)
        {
            foreach (var speciesGroup in speciesGroups)
            {
                if (speciesGroup.Name == speciesGroupName)
                {
                    return speciesGroup;
                }

                if (speciesGroup.SubGroup != null)
                {
                    foreach (var subGroup in speciesGroup.SubGroup.Filters)
                    {
                        if (subGroup.Name == speciesGroupName)
                        {
                            return subGroup;
                        }
                    }
                }
            }
            return null;
        }

        public static string GetSpeciesGroupByShortName(string shortName)
        {
            var speciesGroups = SpeciesGroups.AlienSpecies2023SpeciesGroups.Filters;

            foreach (var species in speciesGroups)
            {
                Filter.FilterItem speciesGroup = species;
                if (speciesGroup.NameShort == shortName)
                {
                    return speciesGroup.Name;
                }

                if (speciesGroup.SubGroup != null)
                {
                    foreach (var subGroup in species.SubGroup.Filters)
                    {
                        if (subGroup.NameShort == shortName)
                        {
                            return subGroup.Name;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
