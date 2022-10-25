namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class AlienSpeciesHelpers
    {
        public static Filter.FilterItem GetSpeciesGroup(Filter.FilterItem[] speciesGroups, string speciesGroupName)
        {
            for (int i = 0; i < speciesGroups.Length; i++)
            {
                Filter.FilterItem speciesGroup = speciesGroups[i];
                if (speciesGroup.Name == speciesGroupName)
                {
                    return speciesGroup;
                }

                if (speciesGroup.SubGroup != null)
                {
                    for (int j = 0; j < speciesGroup.SubGroup.Length; j++)
                    {
                        Filter.FilterItem subGroup = speciesGroup.SubGroup[j];
                        if (subGroup.Name == speciesGroupName)
                        {
                            return subGroup;
                        }
                    }
                }
            }
            return null;
        }
    }
}
