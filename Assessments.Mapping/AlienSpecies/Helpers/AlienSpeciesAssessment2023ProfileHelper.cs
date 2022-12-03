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
                _ => AlienSpeciesAssessment2023ChangedFromAlien.Unknown
            };
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

        internal static bool GetHasIndoorProduction(string indoorProductionString)
        {
            if (string.IsNullOrEmpty(indoorProductionString))
                return false;
            if (indoorProductionString.Equals("negative"))
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
            // 0 maps to "Ukjent" (unknown) in the view. All assessments should have a taxonomic rank, but at this time not all do.
            // 22 through 24 corresponds to species, sub species, and variety, respectively. 
            // These numbers might seem mysterious, but I can assure you, they are not. 
            // The numbers are used in multiple repositories, and corresponds to the correct taxon rank, of which there are about 25. 
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
            foreach (var key in keys)
            {
                if (best >= key)
                    return table[key];
            }
            return 0;
        }

        internal static int IntroductionsLow(RiskAssessment ra)
        {
            int num = IntroductionNum(introLowTable, ra.IntroductionsBest);
            return (int)(num == 0 ? 0 : ra.IntroductionsBest - num);
        }

        internal static int IntroductionsHigh(RiskAssessment ra)
        {
            int num = IntroductionNum(introHighTable, ra.IntroductionsBest);
            return (int)(num == 0 ? 0 : ra.IntroductionsBest + num);
        }

        private static long? AOO10yr(long? occurrences1, long? introductions)
        {
            if (introductions.HasValue == false || occurrences1.HasValue == false)
            {
                return null;
            }
            var occ = occurrences1.Value;
            var intr = introductions.Value;
            if (occ is 0 && intr is 0)
            {
                return 0;
            }
            else return occ is 0 ? (long)(4 * Math.Round(0.64 + 0.36 * intr, 0)) : (long)(4 * Math.Round(occ + Math.Pow(intr, ((double)occ + 9) / 10)));
        }

        internal static int GetAOOfuture(FA4 assessment, RiskAssessment riskAssessment, string estimateQuantile)
        {
            if (assessment.AssessmentConclusion == "WillNotBeRiskAssessed")
            {
                return 0;
            }
            //TODO: use ra.Occurrences1Low/Best/High without asking for HasValue (??) when all assessments are ready before innsynet (should not be any null for doorknockers at that point..)
            long? areaOfOccurrenceIn50Years;
            long? numberOfOccurrences;
            int numberOfIntroductions;
            if (estimateQuantile == "low")
            {
                areaOfOccurrenceIn50Years = riskAssessment.AOO50yrLowInput;
                numberOfOccurrences = riskAssessment.Occurrences1Low ?? 0;
                numberOfIntroductions = IntroductionsLow(riskAssessment);

            }
            else if (estimateQuantile == "best")
            {
                areaOfOccurrenceIn50Years = riskAssessment.AOO50yrBestInput;
                numberOfOccurrences = riskAssessment.Occurrences1Best ?? 0;
                numberOfIntroductions = (int?)riskAssessment.IntroductionsBest ?? 0;
            }
            else
            {
                areaOfOccurrenceIn50Years = riskAssessment.AOO50yrHighInput;
                numberOfOccurrences = riskAssessment.Occurrences1High ?? 0;
                numberOfIntroductions = IntroductionsHigh(riskAssessment);
            }

            var norway = "N";
            var assessedSelfReproducing = "AssessedSelfReproducing";
            var value = 0;
            if (assessment.Limnic)
                value += 1;
            if (assessment.Marine)
                value += 2;
            if (assessment.Terrestrial)
                value += 4;

            switch (value)
            {
                case 1:
                    if (assessment.EvaluationContext == norway)
                    {
                        return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(22000, (long)areaOfOccurrenceIn50Years) : Math.Min(22000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                    }
                    return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(500, (long)areaOfOccurrenceIn50Years) : Math.Min(500, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                case 2:
                    if (assessment.EvaluationContext == norway)
                    {
                        return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(934000, (long)areaOfOccurrenceIn50Years) : Math.Min(934000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                    }
                    return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(1099000, (long)areaOfOccurrenceIn50Years) : Math.Min(1099000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                case 3:
                    if (assessment.EvaluationContext == norway)
                    {
                        return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(956000, (long)areaOfOccurrenceIn50Years) : Math.Min(956000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                    }
                    return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(1099500, (long)areaOfOccurrenceIn50Years) : Math.Min(1099500, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                case 4:
                    if (assessment.EvaluationContext == norway)
                    {
                        return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(310000, (long)areaOfOccurrenceIn50Years) : Math.Min(310000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                    }
                    return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(24000, (long)areaOfOccurrenceIn50Years) : Math.Min(24000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                case 5:
                    if (assessment.EvaluationContext == norway)
                    {
                        return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(332000, (long)areaOfOccurrenceIn50Years) : Math.Min(332000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                    }
                    return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(24500, (long)areaOfOccurrenceIn50Years) : Math.Min(24500, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                case 6:
                    if (assessment.EvaluationContext == norway)
                    {
                        return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(1244000, (long)areaOfOccurrenceIn50Years) : Math.Min(1244000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                    }
                    return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(1123000, (long)areaOfOccurrenceIn50Years) : Math.Min(1123000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                case 7:
                    if (assessment.EvaluationContext == norway)
                    {
                        return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(1266000, (long)areaOfOccurrenceIn50Years) : Math.Min(1266000, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                    }
                    return (int)(assessment.AssessmentConclusion == assessedSelfReproducing ? Math.Min(1123500, (long)areaOfOccurrenceIn50Years) : Math.Min(1123500, (long)AOO10yr(numberOfOccurrences, numberOfIntroductions)));
                default:
                    return 0;
            }
        }
    }
}
