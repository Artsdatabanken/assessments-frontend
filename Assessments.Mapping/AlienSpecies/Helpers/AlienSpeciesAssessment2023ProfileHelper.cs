using System;
using System.Collections.Generic;

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

        internal static string[] GetGeographicVarCause(string category, string geographicVar, List<string> geoVarCause)
        {
            if (GetGeographicVarInCat(category, geographicVar) is null or false)
            {
                return Array.Empty<string>();
            }

            return geoVarCause.ToArray();
        }

        internal static string GetGeographicVarDoc(string category, string geographicVar, string geoVarDoc)
        {
            if (GetGeographicVarInCat(category, geographicVar) is null or false)
            {
                return string.Empty;
            }

            return geoVarDoc;
        }

        internal static bool? GetClimateEffectsInvationpotential(string category, string criteria, string climateEffectsInvationpotential)
        {
            if (category is "NR")
            {
                return null;
            }
            if (string.IsNullOrEmpty(climateEffectsInvationpotential) || GetScores(category, criteria, "inv") == 1)
            {
                return false;
            }
            return climateEffectsInvationpotential == "yes";
        }

        internal static bool? GetClimateEffectsEcoEffect(string category, string criteria, string climateEffectsEcoEffect)
        {
            if (category is "NR")
            {
                return null;
            }
            if (string.IsNullOrEmpty(climateEffectsEcoEffect) || GetScores(category, criteria, "eco") == 1)
            {
                return false;
            }
            return climateEffectsEcoEffect == "yes";
        }

        internal static string GetClimateEffectsDoc(string category, string criteria, string climateEffectsInvationpotential, string climateEffectsEcoEffect, string climateDoc)
        {
            if (GetClimateEffectsInvationpotential(category, criteria, climateEffectsInvationpotential) is null or false && GetClimateEffectsEcoEffect(category, criteria, climateEffectsEcoEffect) is null or false)
            {
                return string.Empty;
            }

            return climateDoc;
        }
    }
}