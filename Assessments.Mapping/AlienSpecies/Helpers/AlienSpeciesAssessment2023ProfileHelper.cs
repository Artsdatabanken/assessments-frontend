using Assessments.Mapping.AlienSpecies.Model;
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

        internal static AlienSpeciesAssessment2023ChangedFromAlien GetAlienSpeciesAssessment2023Changed(string changedFrom)
        {
            return changedFrom switch
            {
                "wasThoughtToBeAlien" => AlienSpeciesAssessment2023ChangedFromAlien.WasThoughtToBeAlien,
                "wasAlienButEstablishedNow" => AlienSpeciesAssessment2023ChangedFromAlien.WasAlienButEstablishedNow,
                _ => AlienSpeciesAssessment2023ChangedFromAlien.Unknown,
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

        internal static bool GetHasIndoorProduction(string indoorProductionString)
        {
            if (string.IsNullOrEmpty(indoorProductionString))
                return false;
            if (indoorProductionString.Equals("positive"))
                return true;
            return false;
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
            var isParsable = int.TryParse(taxonRank, out var result);
            if (!isParsable && taxonRank == "Species")
                result = 22;

            return result;
        }

        internal static List<AlienSpeciesAssessment2023PreviousAssessment> GetPreviousAssessments(List<AlienSpeciesAssessment2023PreviousAssessment> previousAssessments)
        {
            foreach (var previousAssessment in previousAssessments)
            {
                if (previousAssessment.RevisionYear == 2018)
                {
                    previousAssessment.Url = $"https://artsdatabanken.no/fremmedarter/2018/{previousAssessment.AssessmentId.Replace("FA3", string.Empty)}";

                    // https://github.com/Artsdatabanken/Fremmedartsbase2023/blob/65212142a2dbb29317a0cc94bfde26688ab1bc67/Prod.Api/Helpers/ExportMapper.cs#L31-L72
                    if (previousAssessment.MainCategory == "NotApplicable" || (previousAssessment.MainCategory == "DoorKnocker" && previousAssessment.MainSubCategory == "noRiskAssessment") || (previousAssessment.MainCategory == "RegionallyAlien" && previousAssessment.MainSubCategory == "noRiskAssessment"))
                    {
                        previousAssessment.Category = AlienSpeciesAssessment2023Category.NR;
                    }
                    else
                    {
                        previousAssessment.Category = previousAssessment.RiskLevel switch
                        {
                            0 => AlienSpeciesAssessment2023Category.NK,
                            1 => AlienSpeciesAssessment2023Category.LO,
                            2 => AlienSpeciesAssessment2023Category.PH,
                            3 => AlienSpeciesAssessment2023Category.HI,
                            4 => AlienSpeciesAssessment2023Category.SE,
                            _ => AlienSpeciesAssessment2023Category.NR
                        };
                    }
                }
                else
                {
                    // TODO: legg til 2012 når formel for utregning er på plass #711
                    previousAssessment.Category = AlienSpeciesAssessment2023Category.NR;
                    previousAssessment.Url = "https://artsdatabanken.no/fremmedartslista2018";
                }
            }

            return previousAssessments;
        }
    }
}
