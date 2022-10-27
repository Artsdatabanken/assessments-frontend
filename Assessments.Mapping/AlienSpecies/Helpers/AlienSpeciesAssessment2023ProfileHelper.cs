using System;

namespace Assessments.Mapping.AlienSpecies.Helpers
{
    internal static class AlienSpeciesAssessment2023ProfileHelper
    {
        internal static string GetAlienSpeciesCategory(string alienSpeciesCategory, string expertGroup)
        {
            if (alienSpeciesCategory == "RegionallyAlien" && expertGroup != "Fisker")
            {
                return "AlienSpecie";
            }
            return alienSpeciesCategory;
        }

        internal static string GetExpertGroup(string expertGroup)
        {
            if (expertGroup.Contains("(Svalbard)"))
            {
                return expertGroup.Replace("(Svalbard)", "");
            }
            if (expertGroup is "Bakterier" or "Kromister" or "Sopper")
            {
                return "Sopper, det gule riket og bakterier";
            }
            return expertGroup;
        }

        internal static string GetEstablishmentCategory(string speciesEstablishmentCategory, string speciesStatus)
        {
            if (speciesStatus == null)
            {
                return string.Empty;
            }
            return speciesStatus != "C3"? speciesStatus: speciesEstablishmentCategory;
        }

        internal static int? GetScores(string category, string criteria, string v)
        {
            if (category is "NR" or "" or null)
            {
                return null;
            }
            else
            {
                int SInv = (int)Char.GetNumericValue(criteria[0]);
                string SEco = criteria.Split(",")[1];
                int SEco2 = (int)Char.GetNumericValue(SEco[0]);
                return v == "inv" ? SInv : SEco2;
            }
        }
    }
}