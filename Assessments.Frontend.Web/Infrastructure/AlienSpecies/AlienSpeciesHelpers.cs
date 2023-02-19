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
        public static string LowerFirstCharacter(string text)
        {
            return char.ToLower(text[0]) + text[1..];
        }

        public static string GetInvasionPotentialExplanation(List<AlienSpeciesAssessment2023Criterion> criteria)
        {
            var explanation = string.Empty;


            if (criteria.Count != 0)
            {
                for (var i = 0; i < criteria.Count; i++)
                {
                    if (i == 0)
                    {
                        explanation += criteria[i].CriteriaLetter.DisplayName();
                    }
                    else
                    {
                        explanation += LowerFirstCharacter(criteria[i].CriteriaLetter.DisplayName());
                    }
                    explanation += $" på {CriteriaDescription(criteria[i].CriteriaLetter, criteria[i].Value)}";
                    if (i + 1 == criteria.Count)
                    {
                        explanation += ".";
                    }
                    else if (i + 2 == criteria.Count)
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

        public static string GetEcologicalEffectExplanation(List<AlienSpeciesAssessment2023Criterion> criteria)
        {
            var hasDE = criteria.Any(x => x.CriteriaLetter == AlienSpeciesAssessment2023CriteriaLetter.D || x.CriteriaLetter == AlienSpeciesAssessment2023CriteriaLetter.E);
            var hasFG = criteria.Any(x => x.CriteriaLetter == AlienSpeciesAssessment2023CriteriaLetter.F || x.CriteriaLetter == AlienSpeciesAssessment2023CriteriaLetter.G);
            var hasH = criteria.Any(x => x.CriteriaLetter == AlienSpeciesAssessment2023CriteriaLetter.H);
            var hasI = criteria.Any(x => x.CriteriaLetter == AlienSpeciesAssessment2023CriteriaLetter.I);

            var controlValue = 0;
            var explanation = "Arten";

            if (hasDE)
                controlValue += 1;
            if (hasFG)
                controlValue += 2;
            if (hasH)
                controlValue += 4;
            if (hasI)
                controlValue += 8;

            var deText = " har negative interaksjoner med stedegne arter";
            var fgText = " medfører endring i naturtyper";
            var hText = " overfører genetisk materiale til stedegne arter";
            var iText = " overfører parasitter/patogener til stedegne arter";
            var noCriteria = " har ingen utslagsgivende kriterier for økologisk effekt";

            explanation += controlValue switch
            {
                1 => $"{deText}.",
                2 => $"{fgText}.",
                3 => $"{deText} og {fgText}.",
                4 => $"{hText}.",
                5 => $"{deText} og {hText}.",
                6 => $"{fgText} og {hText}.",
                7 => $"{deText}, {fgText} og {hText}.",
                8 => $"{iText}.",
                9 => $"{deText} og {iText}.",
                10 => $"{fgText} og {iText}.",
                11 => $"{deText}, {fgText} og {iText}.",
                12 => $"{hText} og {iText}.",
                13 => $"{deText}, {hText} og {iText}.",
                14 => $"{fgText}, {hText} og {iText}.",
                15 => $"{deText}, {fgText}, {hText} og {iText}.",
                _ => $"{noCriteria}."
            };

            return explanation;
        }

        public static string GetLowerEcologicalEffectsText(AlienSpeciesAssessment2023Category category)
        {
            AlienSpeciesAssessment2023Category[] categoriesArray = (AlienSpeciesAssessment2023Category[])Enum.GetValues(typeof(AlienSpeciesAssessment2023Category));
            // Not able to use Array.ToList() for some reason. Manually converting it... If you come across this and know the reason, please feel free to fix it :)
            List<AlienSpeciesAssessment2023Category> categoriesList = new();
            foreach (var cat in categoriesArray)
            {
                categoriesList.Add(cat);
            }
            var index = Array.IndexOf(categoriesArray, category);
            var categoryTexts = string.Empty;

            // Decrements because enum is from high to low. Doing it this way, we don't have to reverse the array twice => Result should also go from high to low. 
            for (var i = index; i >= 0; i--)
            {
                categoryTexts += $"<i>{categoriesList[i].DisplayName().ToLowerInvariant()}</i>";
                if (i > 1)
                {
                    categoryTexts += ", ";
                }
                else if (i == 1)
                {
                    categoryTexts += " eller ";
                }
            }
            return categoryTexts;
        }
    }
}
