using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Source;

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

        //TODO: add Best and High in same function?  Use dictionary?. Separate between Svalbard and Fastlandet. 
        private static Dictionary<int, int> introLowTable = new Dictionary<int, int>()
        {
            { 1, 1 },
            { 5, 2 },
            { 13, 3 },
            { 26, 4 },
            { 43, 5 },
            { 65, 6 },
            { 91, 7 },
            { 121, 8 },
            { 156, 9 },
            { 195, 10 }
        };

        private static Dictionary<int, int> introHighTable = new Dictionary<int, int>()
        {
            { 1, 1 },
            { 6, 2 },
            { 15, 3 },
            { 29, 4 },
            { 47, 5 },
            { 69, 6 },
            { 96, 7 },
            { 127, 8 },
            { 163, 9 },
            { 204, 10 }
        };

        private static int IntroductionNum(Dictionary<int, int> table, long? best)
        {
            var keys = table.Keys.Reverse();
            var i = 0;
            foreach (var key in keys)
            {
                if (best >= key)
                {
                    i = table[key];
                    break;
                }
            }
            return i;
        }

        private static long IntroductionsLow(RiskAssessment ra)
        {
            long num = IntroductionNum(introLowTable, ra.IntroductionsBest);
            return (long)(num == 0 ? 0 : ra.IntroductionsBest - num);
        }

        private static long introductionsHigh(RiskAssessment ra)
        {
            long num = IntroductionNum(introHighTable, ra.IntroductionsBest);
            return (long)(num == 0 ? 0 : ra.IntroductionsBest + num);
        }

        private static long? AOO10yr(long? occurrences1, long? introductions)
        {
            if (introductions.HasValue == false || occurrences1.HasValue == false)
            {
                return null;
            }
            var occ = occurrences1.Value;
            var intr = introductions.Value;
            long result = occ == 0 && intr == 0
                    ? 0
                    : occ == 0
                        ? (long)(4 * Math.Round(0.64 + 0.36 * intr, 0))
                        : (long)(4 * Math.Round(occ + Math.Pow(intr, ((double)occ + 9) / 10)));

            return result;
        }

        private static long? AOO10yrBest(RiskAssessment ra)
        {
            var result = AOO10yr(ra.Occurrences1Best, ra.IntroductionsBest);
            return result;
        }

        private static long? AOO10yrHigh(RiskAssessment ra)
        {
            var result = AOO10yr(ra.Occurrences1High, introductionsHigh(ra));
            return result;
        }

        internal static ulong? GetAOOfutureLow(FA4 ass, RiskAssessment ra)
        {
            //TODO: use ra.Occurrences1Low directly in function when all assessments are ready before innsynet (should not be any null for doorknockers at that point..)
            var occurrences1Low = ra.Occurrences1Low.HasValue ? ra.Occurrences1Low : 0;
            if (ass.Limnic && !ass.Marine && !ass.Terrestrial && ass.AssessmentConclusion != "WillNotBeRiskAssessed") //limnic species
            {
                if (ass.EvaluationContext is "N")
                {
                    return ass.AssessmentConclusion is "AssessedSelfReproducing" ? Math.Min(22000, (ulong)ra.AOO50yrLowInput) : Math.Min(22000, (ulong)AOO10yr(occurrences1Low, IntroductionsLow(ra))); //ra.Occurrences1Low.HasValue? (ulong)AOO10yr(ra.Occurrences1Low, IntroductionsLow(ra)) : 0
                }
                return ass.AssessmentConclusion is "AssessedSelfReproducing" ? Math.Min(500, (ulong)ra.AOO50yrLowInput) : Math.Min(500, (ulong)AOO10yr(occurrences1Low, IntroductionsLow(ra)));
            }
            if (ass.Limnic && ass.Marine && !ass.Terrestrial && ass.AssessmentConclusion != "WillNotBeRiskAssessed") //limnic and marine species
            {
                if (ass.EvaluationContext is "N")
                {
                    return ass.AssessmentConclusion is "AssessedSelfReproducing" ? Math.Min(956000, (ulong)ra.AOO50yrLowInput) : Math.Min(956000, (ulong)AOO10yr(occurrences1Low, IntroductionsLow(ra)));
                }
                return ass.AssessmentConclusion is "AssessedSelfReproducing" ? Math.Min(1099500, (ulong)ra.AOO50yrLowInput) : Math.Min(1099500, (ulong)AOO10yr(occurrences1Low, IntroductionsLow(ra)));
            }
            return null;
        }
    }
}
