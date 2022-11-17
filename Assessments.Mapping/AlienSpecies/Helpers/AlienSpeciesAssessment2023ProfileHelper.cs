using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Mapping.AlienSpecies.Source;
using Assessments.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

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

        internal static AlienSpeciesAssessment2023Environment GetEnvironmentEnum(bool limnic, bool marine, bool terrestrial)
        {
            var value = 0;
            if (limnic)
                value += 1;
            if (marine)
                value += 2;
            if (terrestrial)
                value += 4;

            return value switch
            {
                1 => AlienSpeciesAssessment2023Environment.Limnisk,
                2 => AlienSpeciesAssessment2023Environment.Marint,
                3 => AlienSpeciesAssessment2023Environment.LimMar,
                4 => AlienSpeciesAssessment2023Environment.Terrestrisk,
                5 => AlienSpeciesAssessment2023Environment.LimTer,
                6 => AlienSpeciesAssessment2023Environment.MarTer,
                7 => AlienSpeciesAssessment2023Environment.LimMarTer,
                _ => AlienSpeciesAssessment2023Environment.Unknown
            };
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
            return speciesStatus != "C3" ? speciesStatus : speciesEstablishmentCategory;
        }

        internal static int? GetScores(string category, string criteria, string axis)
        {
            if (string.IsNullOrEmpty(category) || category is "NR")
            {
                return null;
            }
            else
            {
                int scoreInvationAxis = (int)Char.GetNumericValue(criteria[0]);
                string criteriaEcoEffectAxis = criteria.Split(",")[1];
                int scoreEcoEffectAxis = (int)Char.GetNumericValue(criteriaEcoEffectAxis[0]);
                return axis == "inv" ? scoreInvationAxis : scoreEcoEffectAxis;
            }
        }

        internal static bool? GetGeographicVarInCat(string category, string geographicVar)
        {
            if (category is "NR")
            {
                return null;
            }
            if (string.IsNullOrEmpty(geographicVar))
            {
                return false;
            }
            return geographicVar == "yes";
        }

        internal static List<string> GetGeographicVarCause(string category, string geographicVar, List<string> geoVarCause)
        {
            if (GetGeographicVarInCat(category, geographicVar) is null or false)
            {
                return new List<string>();
            }

            return geoVarCause;
        }

        internal static string GetGeographicVarDoc(string category, string geographicVar, string geoVarDoc)
        {
            if (GetGeographicVarInCat(category, geographicVar) is null or false)
            {
                return string.Empty;
            }

            return geoVarDoc;
        }

        internal static bool? GetClimateEffects(string category, string criteria, string axis, RiskAssessment ra)
        {
            if (category is "NR")
            {
                return null;
            }
            string climateEffect = axis == "inv" ? ra.ClimateEffectsInvationpotential : ra.ClimateEffectsEcoEffect;

            if (string.IsNullOrEmpty(climateEffect) || GetScores(category, criteria, axis) == 1)
            {
                return false;
            }
            return climateEffect == "yes";
        }

        internal static string GetClimateEffectsDoc(string category, string criteria, RiskAssessment ra, string climateDoc)
        {
            if (GetClimateEffects(category, criteria, "inv", ra) is null or false && GetClimateEffects(category, criteria, "eco", ra) is null or false)
            {
                return string.Empty;
            }

            return climateDoc;
        }

        internal static string GetSpeciesGroup(string taxonHierarchy)
        {
            // Reversing the list to get a match as low as possible in the taxon hierarchy.
            var scientificNames = taxonHierarchy.Split("/").Reverse();
            AlienSpeciesAssessment2023SpeciesGroups speciesGroup;
            foreach (var name in scientificNames)
            {
                if (Enum.TryParse(name, out speciesGroup))
                {
                    return speciesGroup.DisplayName();
                }
            }
            return String.Empty;
        }

        internal static int GetTaxonRank(string taxonRank)
        {
            // 0 maps to "Ukjent" (unknown) in the view. All assessments should have a taxonomic rank, but at this time not all do.
            // 22 through 24 corresponds to species, sub species, and variety, respectively. 
            // These numbers might seem mysterious, but I can assure you, they are not. 
            // The numbers are used in multiple repositories, and corresponds to the correct taxon rank, of which there are about 25. 
            var result = 0;
            var isParsable = int.TryParse(taxonRank, out result);
            if (!isParsable && taxonRank == "Species")
                result = 22;

            return result;
        }
    }
}
