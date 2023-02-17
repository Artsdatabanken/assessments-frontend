using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static string CriteriaDescription(AlienSpeciesAssessment2023CriteriaLetter letter, int value)
        {
            var description = string.Empty;

            switch (letter)
            {
                case AlienSpeciesAssessment2023CriteriaLetter.A:
                    description = value switch
                    {
                        1 => "mindre enn 10 år",
                        2 => "mellom 10 og 59 år",
                        3 => "mellom 60 og 649 år",
                        4 => "minimum 650 år",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.B:
                    description = value switch
                    {
                        1 => "mindre enn 50 m/år",
                        2 => "mellom 50 og 159 m/år",
                        3 => "mellom 160 og 499 m/år",
                        4 => "minimum 500 m/år",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.C:
                    description = value switch
                    {
                        1 => "mindre enn 5%",
                        2 => "minimum 5%",
                        3 => "minimum 10%",
                        4 => "minimum 20%",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.D:
                    description = value switch
                    {
                        1 => "fraværende",
                        2 => "svak styrke og begrenset omfang",
                        3 => "svak styrke og storskala omfang ELLER moderat styrke og begrenset omfang",
                        4 => "moderat styrke og storskala omfang ELLER fortrengning",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.E:
                    description = value switch
                    {
                        1 => "svak styrke ELLER moderat styrke og begrenset omfang",
                        2 => "moderat styrke og storskala omfang",
                        3 => "fortrengning i begrenset omfang",
                        4 => "fortrengning i storskala omfang",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.F:
                    description = value switch
                    {
                        1 => "0%",
                        2 => "over 0%",
                        3 => "minimum 2%",
                        4 => "minimum 5%",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.G:
                    description = value switch
                    {
                        1 => "mindre enn 5%",
                        2 => "minimum 5%",
                        3 => "minimum 10%",
                        4 => "minimum 20%",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.H:
                    description = value switch
                    {
                        1 => "ingen overføring",
                        2 => "begrenset til rødlistevurdert art",
                        3 => "storskala til rødlistevurdert art ELLER begrenset til truet art eller nøkkelart",
                        4 => "storskala til truet art eller nøkkelart",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.I:
                    description = value switch
                    {
                        1 => "ingen overføring ELLER begrenset til art som allerede er vert for denne parasitten",
                        2 => "storskala til art som allerede er vert for denne parasitten ELLER begrenset til ny vert",
                        3 => "storskala av eksisterende parasitt til ny vert ELLER begrenset til ny truet vert",
                        4 => "storskala av eksisterende parasitt til ny truet vert ELLER storskala eller begrenset av en fremmed parasitt",
                        _ => description
                    };
                    break;
                default:
                    return description;
            }

            return description;
        }

        public static int GetUncertaintyValueMinMax(int value, int uncertainty)
        {
            return uncertainty == 0 ? value : uncertainty;
        }
        public static int GetUncertaintyHigh(AlienSpeciesAssessment2023Criterion criterion)
        {
            return criterion.UncertaintyValues.Where(x => x > criterion.Value).FirstOrDefault();
        }
        public static int GetUncertaintyLow(AlienSpeciesAssessment2023Criterion criterion)
        {
            return criterion.UncertaintyValues.Where(x => x < criterion.Value).FirstOrDefault();
        }

        public static string GetLetterFullText(AlienSpeciesAssessment2023Criterion criterion, bool isDifferent)
        {
            var letterText = criterion.CriteriaLetter.DisplayName();
            letterText += isDifferent == true ? " som er " : " på ";
            letterText += CriteriaDescription(criterion.CriteriaLetter, criterion.Value);
            letterText += GetUncertaintyHigh(criterion) == 0 && GetUncertaintyLow(criterion) == 0 ? "." : "";
            if (GetUncertaintyHigh(criterion) != 0 || GetUncertaintyLow(criterion) != 0)
            {
                letterText += "(med usikkerhet ";
            }
            if (GetUncertaintyLow(criterion) != 0)
            {
                letterText += $"ned mot {CriteriaDescription(criterion.CriteriaLetter, AlienSpeciesHelpers.GetUncertaintyLow(criterion))}";
                letterText += GetUncertaintyHigh(criterion) == 0 && GetUncertaintyLow(criterion) != 0 ? ")." : "";
            }
            if (GetUncertaintyHigh(criterion) != 0 && GetUncertaintyLow(criterion) != 0)
            {
                letterText += " og ";
            }
            if (AlienSpeciesHelpers.GetUncertaintyHigh(criterion) != 0)
            {
                letterText += $"opp mot {CriteriaDescription(criterion.CriteriaLetter, GetUncertaintyHigh(criterion))}";
                letterText += GetUncertaintyHigh(criterion) != 0 || GetUncertaintyLow(criterion) != 0 ? ")." : "";
            }

            return letterText;
        }

        public static string GetCriteriaExplanation(List<AlienSpeciesAssessment2023Criterion> criteria)
        {
            var explanation = string.Empty;

            string Lower(string text)
            {
                return char.ToLower(text[0]) + text[1..];
            }

            if (criteria.Count() != 0)
            {
                for (var i = 0; i < criteria.Count(); i++)
                {
                    if (i == 0)
                    {
                        explanation += criteria[i].CriteriaLetter.DisplayName();
                    }
                    else
                    {
                        explanation += Lower(criteria[i].CriteriaLetter.DisplayName());
                    }
                    explanation += $"på {CriteriaDescription(criteria[i].CriteriaLetter, criteria[i].Value)}";
                    if (i + 1 == criteria.Count())
                    {
                        explanation += ".";
                    }
                    else if (i + 2 == criteria.Count())
                    {
                        explanation += " og ";
                    }
                    else
                    {
                        explanation += ", ";
                    }
                }
            }
            return explanation;
        }
    }
}
