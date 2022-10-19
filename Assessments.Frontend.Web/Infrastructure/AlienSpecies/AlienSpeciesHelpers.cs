namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class AlienSpeciesHelpers
    {
        public static SpeciesGroups.SpeciesGroupItem GetSpeciesGroup(SpeciesGroups.SpeciesGroupItem[] speciesGroups, string speciesGroupName)
        {
            for (int i = 0; i < speciesGroups.Length; i++)
            {
                SpeciesGroups.SpeciesGroupItem speciesGroup = speciesGroups[i];
                if (speciesGroup.SpeciesName == speciesGroupName)
                {
                    return speciesGroup;
                }

                if (speciesGroup.SubGroup != null)
                {
                    for (int j = 0; j < speciesGroup.SubGroup.Length; j++)
                    {
                        SpeciesGroups.SpeciesGroupItem subGroup = speciesGroup.SubGroup[j];
                        if (subGroup.SpeciesName == speciesGroupName)
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
