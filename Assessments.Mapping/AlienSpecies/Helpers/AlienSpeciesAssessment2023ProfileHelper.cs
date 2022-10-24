

namespace Assessments.Mapping.AlienSpecies.Helpers
{
    internal static class AlienSpeciesAssessment2023ProfileHelper
    {
        internal static string GetAlienSpeciesCategory(string AlienSpeciesCategory, string ExpertGroup)
        {
            if(AlienSpeciesCategory == "RegionallyAlien" && ExpertGroup != "Fisker")
            {
                return "AlienSpecie";
            }
            else return AlienSpeciesCategory;
        }

        internal static string GetExpertGroup(string ExpertGroup)
        {
            if(ExpertGroup.Contains("(Svalbard)"))
            {
                return ExpertGroup.Replace("(Svalbard)", "");
            }
            if(ExpertGroup == "Bakterier" || ExpertGroup == "Kromister" || ExpertGroup == "Sopper")
            {
                return "Sopper, det gule riket og bakterier";
            }
            else return ExpertGroup;
        }
        internal static string GetEstablishmentCategory(string SpeciesEstablishmentCategory, string SpeciesStatus)
        {
            if(SpeciesStatus == null)
            {
                return string.Empty;
            }
            else if (SpeciesStatus != "C3")
            {
                return SpeciesStatus;
            }
            else return SpeciesEstablishmentCategory;
        }
    }
}