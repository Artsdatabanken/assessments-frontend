﻿using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using Assessments.Shared.Resources.Enums.AlienSpecies;
using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Assessments.Frontend.Web.Infrastructure.AlienSpecies.DeciciveCriteria;
using static Assessments.Frontend.Web.Infrastructure.FilterHelpers;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class Areas
    {
        private readonly FilterItem[] AlienSpecies2023AreasFilters = Enum.GetValues<AlienSpeciesAssessment2023EvaluationContext>()
            .Select(x => new FilterItem
            {
                Name = x.DisplayName(),
                NameShort = x.ToString()
            }).ToArray();


        public FilterAndMetaData AlienSpecies2023Areas() =>
            new()
            {
                Filters = AlienSpecies2023AreasFilters,
                FilterDescription = "",
                FilterButtonName = "områdefiltre",
                FilterButtonText = Resources.SharedResources.area
            };
    }

    public class Categories
    {
        private readonly FilterItem[] AlienSpecies2023InvasionPotentialFilters = Enum.GetValues<AlienSpeciesAssessment2023MatrixAxisScore.InvasionPotential>()
            .Select(x => new FilterItem
            {
                NameShort = x.Description(),
                Name = x.DisplayName()
            }).Skip(1).ToArray();

        public FilterAndMetaData AlienSpecies2023InvasionPotential() =>
            new()
            {
                Filters = AlienSpecies2023InvasionPotentialFilters,
                FilterDescription = "Artens levedyktighet og evne til å ekspandere",
                FilterButtonName = "invasjonspotensialfiltre",
                FilterButtonText = "Invasjonspotensial (risikomatrisens x-akse)"
            };

        private readonly FilterItem[] AlienSpecies2023EcologicalEffectFilters = Enum.GetValues<AlienSpeciesAssessment2023MatrixAxisScore.EcologicalEffect>()
            .Select(x => new FilterItem
            {
                NameShort = x.Description(),
                Name = x.DisplayName()
            }).Skip(1).ToArray();

        public FilterAndMetaData AlienSpecies2023EcologicalEffect() => 
            new()
            {
                Filters = AlienSpecies2023EcologicalEffectFilters,
                FilterDescription = "Påvirkning på arter og naturtyper i Norge",
                FilterButtonName = "okologiskeffektfiltre",
                FilterButtonText = "Økologisk effekt (risikomatrisens y-akse)"
            };

        private readonly FilterItem[] _alienSpecies2023CategoriesFilters = Enum.GetValues<AlienSpeciesAssessment2023Category>()
            .Where(x => x != AlienSpeciesAssessment2023Category.NR)
            .Select(x => new FilterItem
            {
                NameShort = x.ToString(),
                Name = x.DisplayName(),
                Description = x.DisplayName()
            }).ToArray();
        public FilterAndMetaData AlienSpecies2023Categories() =>
            new()
            {
                Filters = _alienSpecies2023CategoriesFilters,
                FilterDescription = "",
                FilterButtonName = "kategorifiltre",
                FilterButtonText = "Risikokategori"
            };
    }

    public enum CategoryChangeEnum
    {
        [Display(Name = "Vurdert for første gang")]
        ccvf,

        [Display(Name = "Kategorien er endret fra 2018")]
        ccke,

        [Display(Name = "Samme kategori som i 2018")]
        ccsk
    }

    public class CategoryChange
    {
        private static FilterAndMetaData DifferFrom2018() =>
        new()
        {
            Filters = Enum.GetValues<AlienSpeciesAssessment2023ReasonForChangeOfCategory>()
                    .Select(x => new FilterItem
                    {
                        Name = x.DisplayName(),
                        NameShort = x.ToString()
                    }).ToArray(),
            FilterDescription = ""
        };

        public readonly FilterItem[] AlienSpecies2023CategoryChangedFilters =
        {
            new()
            {
                Name = CategoryChangeEnum.ccvf.DisplayName(),
                NameShort = CategoryChangeEnum.ccvf.ToString()
            },
            new()
            {
                Name = CategoryChangeEnum.ccke.DisplayName(),
                NameShort = CategoryChangeEnum.ccke.ToString(),
                SubGroup = DifferFrom2018()
            },
            new()
            {
                Name = CategoryChangeEnum.ccsk.DisplayName(),
                NameShort = CategoryChangeEnum.ccsk.ToString()
            }
        };

        public FilterAndMetaData AlienSpecies2023CategoryChanged() => 
            new()
            {
                Filters = AlienSpecies2023CategoryChangedFilters,
                FilterDescription = "",
                FilterButtonName = "kategoriendringsfiltre",
                FilterButtonText = "Endring i risikokategori"
            };
    }

    public class DeciciveCriteria
    {
        public enum DecisiveCriteriaInvasion
        {
            A = AlienSpeciesAssessment2023CriteriaLetter.A,
            B = AlienSpeciesAssessment2023CriteriaLetter.B,
            C = AlienSpeciesAssessment2023CriteriaLetter.C,
            [Display(Name = "A×B hvor høyeste skår er...")] //TODO: move to resource
            AxBdescribsion,
            [Display(Name = "A×B - Median levetid x Ekspansjonshastighet")] //TODO: move to resource
            AxB,
        };

        public enum DecisiveCriteriaEcologicalEffect
        {
            D = AlienSpeciesAssessment2023CriteriaLetter.D,
            E = AlienSpeciesAssessment2023CriteriaLetter.E,
            F = AlienSpeciesAssessment2023CriteriaLetter.F,
            G = AlienSpeciesAssessment2023CriteriaLetter.G,
            H = AlienSpeciesAssessment2023CriteriaLetter.H,
            I = AlienSpeciesAssessment2023CriteriaLetter.I
        };

        public static FilterAndMetaData MedianLifeTimeAndExpansionSpeed() =>
            new()
            {
                Filters = 
                    Enum.GetValues<DecisiveCriteriaInvasion>().Where(x => x is DecisiveCriteriaInvasion.A or DecisiveCriteriaInvasion.B)
                    .Select(x => new FilterItem
                    {
                        Name = x.ToString() + " - " + ((AlienSpeciesAssessment2023CriteriaLetter)x).DisplayName(),
                        NameShort = x.ToString()
                    }).ToArray()
                ,
                FilterDescription = ""
            };

        private static FilterAndMetaData InvationPotential() =>
           new()
           {
               Filters = Enum.GetValues<DecisiveCriteriaInvasion>().Where(x => x != DecisiveCriteriaInvasion.A & x != DecisiveCriteriaInvasion.B)
               .Select(x => new FilterItem
                   {
                        Name = x != DecisiveCriteriaInvasion.C ?  x.DisplayName()
                        : x.ToString() + " - " + ((AlienSpeciesAssessment2023CriteriaLetter)x).DisplayName(),
                        NameShort = x.ToString(),
                        SubGroup = x == DecisiveCriteriaInvasion.AxBdescribsion ? MedianLifeTimeAndExpansionSpeed() : null
                   }
               ).Reverse().ToArray(),
                   
               FilterDescription = "" 
           };

        public static FilterAndMetaData EcologicalEffect() =>
        new()
        {
            Filters = Enum.GetValues<DecisiveCriteriaEcologicalEffect>()
                    .Select(x => new FilterItem
                    {
                        Name = x.ToString() + " - " + ((AlienSpeciesAssessment2023CriteriaLetter) x).DisplayName(),
                        NameShort = x.ToString()
                    }).ToArray(),
            FilterDescription = ""
        };

        public readonly FilterItem[] AlienSpecies2023DeciciveCriteriaFilters =
        {
            new()
            {
                Name = "Invasjonspotensial",
                NameShort = "dcin",
                SubGroup = InvationPotential()
            },
            new()
            {
                Name = "Økologisk effekt",
                NameShort = "dcok",
                SubGroup = EcologicalEffect()
                   
            }
        };

        public FilterAndMetaData AlienSpecies2023DeciciveCriteria() =>
            new()
            {
                Filters = AlienSpecies2023DeciciveCriteriaFilters,
                FilterDescription = "",
                FilterButtonName = "avgjorende kriterier-filtre",
                FilterButtonText = "Avgjørende kriterier for kategori"
            };
    }

    public class Environments
    {
        public const string Marine = "Ema";
        public const string Limnic = "Eli";
        public const string Terrestrial = "Ete";

        public readonly FilterItem[] AlienSpecies2023EnvironmentFilters =
        {
            new()
            {
                Name = AlienSpeciesAssessment2023Environment.Marint.DisplayName(),
                NameShort = "Ema",
            },
            new()
            {
                Name = AlienSpeciesAssessment2023Environment.Limnisk.DisplayName(),
                NameShort = "Eli",
            },
            new()
            {
                Name = AlienSpeciesAssessment2023Environment.Terrestrisk.DisplayName(),
                NameShort = "Ete",
            }
        };

        public FilterAndMetaData AlienSpecies2023Environment() =>
            new()
            {
                Filters = AlienSpecies2023EnvironmentFilters,
                FilterDescription = "",
                FilterButtonName = "livsmiljø-filtre",
                FilterButtonText = "Livsmiljø"
            };
    }

    public class GeographicVariation
    {
        public enum GeographicVariationEnum
        {
            [Display(Name = "Risikoen er ulik innenfor artens potensielle forekomstareal")]
            Gvv,

            [Display(Name = "Risikoen er den samme innenfor artens potensielle forekomstareal")]
            Gvn,
        };

        public static readonly FilterItem[] AlienSpecies2023GeographicVariationFilters =
        {
            new ()
            {
                Name = GeographicVariationEnum.Gvv.DisplayName(),
                NameShort = nameof(GeographicVariationEnum.Gvv)
            },
            new()
            {
                Name = GeographicVariationEnum.Gvn.DisplayName(),
                NameShort = nameof(GeographicVariationEnum.Gvn)
            }
        };

        public static readonly FilterAndMetaData AlienSpecies2023GeographicVariation = new()
        {
            Filters = AlienSpecies2023GeographicVariationFilters,
            FilterDescription = "",
            FilterButtonName = "'geografisk variasjon'-filtre",
            FilterButtonText = "Geografisk variasjon i risiko"
        };
    }

    public class ClimateEffects
    {
        public enum ClimateEffectsEnum
        {
            [Display(Name = "Invasjonspotensial påvirket av klimaendringer")]
            Cepi,

            [Display(Name = "Økologisk effekt påvirket av klimaendringer")]
            Cepo,

            [Display(Name = "Invasjonspotensial ikke påvirket av klimaendringer")]
            Ceii,

            [Display(Name = "Økologisk effekt ikke påvirket av klimaendringer")]
            Ceio,

            [Display(Name = "Påvirket av klimaendringer")]
            Cep,

            [Display(Name = "Ikke påvirket av klimaendringer")]
            Cei,
        };

        public static readonly FilterItem[] AlienSpecies2023ClimateEffectsFiltersAffected =
        {
            new ()
            {
                Name = ClimateEffectsEnum.Cepi.DisplayName(),
                NameShort = nameof(ClimateEffectsEnum.Cepi),
            },
            new()
            {
                Name = ClimateEffectsEnum.Cepo.DisplayName(),
                NameShort = nameof(ClimateEffectsEnum.Cepo),
            }
        };

        public static readonly FilterItem[] AlienSpecies2023ClimateEffectsFiltersNotAffected =
        {
            new ()
            {
                Name = ClimateEffectsEnum.Ceii.DisplayName(),
                NameShort = nameof(ClimateEffectsEnum.Ceii),
            },
            new()
            {
                Name = ClimateEffectsEnum.Ceio.DisplayName(),
                NameShort = nameof(ClimateEffectsEnum.Ceio),
            }
        };

        public static readonly FilterItem[] AlienSpecies2023ClimateEffectsFilters =
        {
            new ()
            {
                Name = ClimateEffectsEnum.Cep.DisplayName(),
                NameShort = nameof(ClimateEffectsEnum.Cep),
                SubGroup = new()
                {
                    Filters = AlienSpecies2023ClimateEffectsFiltersAffected,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = ClimateEffectsEnum.Cei.DisplayName(),
                NameShort = nameof(ClimateEffectsEnum.Cei),
                SubGroup = new()
                {
                    Filters = AlienSpecies2023ClimateEffectsFiltersNotAffected,
                    FilterDescription = ""
                }
            }
        };

        public static readonly FilterAndMetaData AlienSpecies2023ClimateEffects = new()
        {
            Filters = AlienSpecies2023ClimateEffectsFilters,
            FilterDescription = "",
            FilterButtonName = "'klimaendringer'-filtre",
            FilterButtonText = "Betydning av klimaendringer for risiko"
        };
    }

    public class NatureTypes
    {
        // Must remove non-threatened nature types from the filter
        public enum ImpactedNaturetypesThreatened
        {
            FreshWaterThreatned = AlienSpeciesAssessment2023MajorTypeGroup.FreshWaterThreatned,
            MountainsThreatned = AlienSpeciesAssessment2023MajorTypeGroup.MountainsThreatned,
            LandformThreatned = AlienSpeciesAssessment2023MajorTypeGroup.LandformThreatned,
            MarineWaterThreatned = AlienSpeciesAssessment2023MajorTypeGroup.MarineWaterThreatned,
            MarineWaterSvalbardThreatned = AlienSpeciesAssessment2023MajorTypeGroup.MarineWaterSvalbardThreatned,
            SemiNaturalThreatned = AlienSpeciesAssessment2023MajorTypeGroup.SemiNaturalThreatned,
            ForestThreatned = AlienSpeciesAssessment2023MajorTypeGroup.ForestThreatned,
            SvalbardThreatned = AlienSpeciesAssessment2023MajorTypeGroup.SvalbardThreatned,
            WetlandsThreatned = AlienSpeciesAssessment2023MajorTypeGroup.WetlandsThreatned
        }

        public static FilterAndMetaData AlienSpecies2023AlteredEcosystems() => 
            new()
            {
                Filters = Enum.GetValues<AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystems>()
                    .Select(x => new FilterItem
                    {
                        Name = x.DisplayName(),
                        NameShort = x.ToString()
                    }).ToArray(),
                FilterDescription = ""
            };

        public static FilterAndMetaData AlienSpecies2023AlteredMajorTypeGroupTypes() =>
            new()
            {
                Filters = Enum.GetValues<ImpactedNaturetypesThreatened>()
                    .Select(x => new FilterItem
                    {
                        Name = ((AlienSpeciesAssessment2023MajorTypeGroup)x).DisplayName(),
                        NameShort = x.ToString()
                    }).ToArray(),
                FilterDescription = ""
            };

        private readonly FilterItem[] AlienSpecies2023NatureTypesFilters =
        {

            new ()
            {
                Name = "Forekomstareal i sterkt endra natur",
                NameShort = "Nta",
                SubGroup = AlienSpecies2023AlteredEcosystems()
            },
            new()
            {
                Name = "Forekomst i truede eller sjeldne naturtyper",
                NameShort = "Ntn",
                SubGroup = AlienSpecies2023AlteredMajorTypeGroupTypes()
            }
        };

        public FilterAndMetaData AlienSpecies2023NatureTypes() => 
            new()
            {
                Filters = AlienSpecies2023NatureTypesFilters,
                FilterDescription = "",
                FilterButtonName = "'naturtyper'-filtre",
                FilterButtonText = "Naturtyper"
            };
    }

    public class SpreadWays
    {
        public enum SpreadWaysEnum
        {
            [Display(Name = "Import til produksjons- eller innendørsareal")]
            Swimp,

            [Display(Name = "Introduksjon til naturen")]
            Swnat,

            [Display(Name = "Spredning i naturen")]
            Swspr
        }

        private static FilterAndMetaData AlienSpecies2023SpreadWaysFiltersImportPathways() =>
           new()
           {
               Filters =
                   Enum.GetValues<AlienSpeciesAssessment2023IntroductionPathway.MainCategory>().Where(x => x is AlienSpeciesAssessment2023IntroductionPathway.MainCategory.ImportDirect or AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Transportpolution or AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Stowaway)
                   .Select(x => new FilterItem
                   {
                       Name = x.Description(),
                       NameShort = x.ToString() + AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.NotChosen.ToString()
                   }).ToArray()
               ,
               FilterDescription = ""
           };

        private static FilterAndMetaData AlienSpecies2023SpreadWaysFiltersIntroduction() =>
           new()
           {
               Filters =
                   Enum.GetValues<AlienSpeciesAssessment2023IntroductionPathway.MainCategory>().Where(x => x is not (AlienSpeciesAssessment2023IntroductionPathway.MainCategory.ImportDirect or AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Unknown))
                   .Select(x => new FilterItem
                   {
                       Name = x.Description(),
                       NameShort = x.ToString() 
                   }).ToArray()
               ,
               FilterDescription = ""
           };

        private static FilterAndMetaData AlienSpecies2023SpreadWaysFiltersSpread() =>
          new()
          {
              Filters =
                  Enum.GetValues<AlienSpeciesAssessment2023IntroductionPathway.MainCategory>().Where(x => x is not (AlienSpeciesAssessment2023IntroductionPathway.MainCategory.ImportDirect or AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Unknown or AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Escaped))
                  .Select(x => new FilterItem
                  {
                      Name = x.Description(),
                      NameShort = x.ToString() + AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Spread.ToString()
                  }).ToArray()
              ,
              FilterDescription = ""
          };

        public readonly FilterItem[] AlienSpecies2023SpreadWaysFilters =
        {
            new ()
            {
                Name = SpreadWaysEnum.Swimp.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swimp),
                SubGroup = AlienSpecies2023SpreadWaysFiltersImportPathways()
            },
            new()
            {
                Name = SpreadWaysEnum.Swnat.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swnat),
                SubGroup = AlienSpecies2023SpreadWaysFiltersIntroduction()
            },
            new()
            {
                Name = SpreadWaysEnum.Swspr.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swspr),
                SubGroup = AlienSpecies2023SpreadWaysFiltersSpread()
            }
        };

        public FilterAndMetaData AlienSpecies2023SpreadWays() => 
            new()
            {
                Filters = AlienSpecies2023SpreadWaysFilters,
                FilterDescription = "",
                FilterButtonName = "'spredningsmåter'-filtre",
                FilterButtonText = "Spredningsmåter"
            };
    }

    public class RegionallyAlien
    {
        public enum RegionallyAlienEnum
        {
            [Display(Name = "Ekskluder regionalt fremmede arter")]
            Rae,

            [Display(Name = "Kun vis regionalt fremmede arter")]
            Rai,

            [Display(Name = "Regionvis utbredelse")]
            Rar,

            [Display(Name = "Agder")]
            Raag,

            [Display(Name = "Bottenhavet")]
            Raboh,

            [Display(Name = "Bottenviken")]
            Rabov,

            [Display(Name = "Innlandet og Viken")]
            Rain,

            [Display(Name = "Kemijoki")]
            Rake,

            [Display(Name = "Møre og Romsdal")]
            Ramo,

            [Display(Name = "Nordland og Jan Mayen")]
            Rano,

            [Display(Name = "Norsk-finsk")]
            Ranof,

            [Display(Name = "Rogaland")]
            Raro,

            [Display(Name = "Torneå")]
            Rator,

            [Display(Name = "Tornionjoki")]
            Ratoj,

            [Display(Name = "Troms og Finnmark")]
            Ratrf,

            [Display(Name = "Trøndelag")]
            Ratro,

            [Display(Name = "Vestfold og Telemark")]
            Ravet,

            [Display(Name = "Vestland")]
            Raves,

            [Display(Name = "Västerhavet")]
            Rava,

        }

        public static readonly FilterItem[] RegionalSpread =
        {
            new()
            {
                Name = RegionallyAlienEnum.Raag.DisplayName(),
                NameShort = RegionallyAlienEnum.Raag.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Raboh.DisplayName(),
                NameShort = RegionallyAlienEnum.Raboh.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Rabov.DisplayName(),
                NameShort = RegionallyAlienEnum.Rabov.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Rain.DisplayName(),
                NameShort = RegionallyAlienEnum.Rain.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Rake.DisplayName(),
                NameShort = RegionallyAlienEnum.Rake.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Ramo.DisplayName(),
                NameShort = RegionallyAlienEnum.Ramo.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Rano.DisplayName(),
                NameShort = RegionallyAlienEnum.Rano.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Ranof.DisplayName(),
                NameShort = RegionallyAlienEnum.Ranof.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Raro.DisplayName(),
                NameShort = RegionallyAlienEnum.Raro.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Rator.DisplayName(),
                NameShort = RegionallyAlienEnum.Rator.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Ratoj.DisplayName(),
                NameShort = RegionallyAlienEnum.Ratoj.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Ratrf.DisplayName(),
                NameShort = RegionallyAlienEnum.Ratrf.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Ratro.DisplayName(),
                NameShort = RegionallyAlienEnum.Ratro.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Ravet.DisplayName(),
                NameShort = RegionallyAlienEnum.Ravet.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Raves.DisplayName(),
                NameShort = RegionallyAlienEnum.Raves.GetHashCode().ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Rava.DisplayName(),
                NameShort = RegionallyAlienEnum.Rava.GetHashCode().ToString()
            },

        };

        public static readonly FilterItem[] AlienSpecies2023RegionallyAlienFilters =
        {
            new()
            {
                Name = RegionallyAlienEnum.Rae.DisplayName(),
                NameShort = RegionallyAlienEnum.Rae.ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Rai.DisplayName(),
                NameShort = RegionallyAlienEnum.Rai.ToString()
            },
            new()
            {
                Name = RegionallyAlienEnum.Rar.DisplayName(),
                NameShort = RegionallyAlienEnum.Rar.ToString(),
                SubGroup = new()
                {
                    Filters = RegionalSpread,
                    FilterDescription = "Vannregioner"
                }
            }
        };

        public static readonly FilterAndMetaData AlienSpecies2023RegionallyAlien = new()
        {
            Filters = AlienSpecies2023RegionallyAlienFilters,
            FilterDescription = "",
            FilterButtonName = "'regionalt fremmed'-filtre",
            FilterButtonText = "Regionalt fremmede arter"
        };
    }

    public class TaxonRank
    {
        public enum TaxonRankEnum
        {
            Species = AlienSpeciesAssessment2023ScientificNameRank.Species,
            Hybrid = AlienSpeciesAssessment2023ScientificNameRank.Hybrid,
            SubSpecies = AlienSpeciesAssessment2023ScientificNameRank.SubSpecies,
            Variety = AlienSpeciesAssessment2023ScientificNameRank.Variety,
            Form = AlienSpeciesAssessment2023ScientificNameRank.Form
        }

        public static FilterAndMetaData AlienSpeciesTaxonRanks2023() =>
            new()
            {
                Filters = Enum.GetValues<TaxonRankEnum>().Select(x => new FilterItem { Name = ((AlienSpeciesAssessment2023ScientificNameRank)x).DisplayName(), NameShort = x.ToString() }).ToArray()
            };

        public readonly FilterItem[] AlienSpecies2023TaxonRanksFilters =
        {
            new()
            {
                Name = AlienSpeciesAssessment2023ScientificNameRank.TaxonomicRank.DisplayName(),
                NameShort = AlienSpeciesAssessment2023ScientificNameRank.TaxonomicRank.ToString(),
                SubGroup = AlienSpeciesTaxonRanks2023()
            },
            new()
            {
                Name = AlienSpeciesAssessment2023ScientificNameRank.AssessedAtAnotherRank.DisplayName(),
                NameShort = AlienSpeciesAssessment2023ScientificNameRank.AssessedAtAnotherRank.ToString()
            },
            new()
            {
                Name = AlienSpeciesAssessment2023ScientificNameRank.AssessedAtSameRank.DisplayName(),
                NameShort = AlienSpeciesAssessment2023ScientificNameRank.AssessedAtSameRank.ToString()
            }
        };

        public FilterAndMetaData AlienSpecies2023TaxonRanks() => 
            new()
            {
                Filters = AlienSpecies2023TaxonRanksFilters,
                FilterDescription = "",
                FilterButtonName = "'taksonomisk nivå'-filtre",
                FilterButtonText = "Taksonomi"
            };
    }

    public class SpeciesGroups
    {
        private static FilterAndMetaData AlienSpecies2023Algae() =>
            new()
            { 
                Filters = 
                Enum.GetValues<AlienSpeciesAssessment2023SpeciesGroups>()
                .Where(x => x is AlienSpeciesAssessment2023SpeciesGroups.Phaeophyceae or AlienSpeciesAssessment2023SpeciesGroups.Chlorophyta or AlienSpeciesAssessment2023SpeciesGroups.Rhodophyta)
                .Select(x => new FilterItem
                {
                    NameShort = x.ToString(),
                    Name = x.DisplayName(),
                    Description = nameof(x),
                    InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                    ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                }).OrderBy(x => x.Name).ToArray(),
                FilterDescription = ""
            };

        //Norwegian names used in this subset-enum to be able to use values in ImageUrl under AlienSpecies2023Insects(). 
        public enum InsectSpeciesGroup
            {
                Biller = AlienSpeciesAssessment2023SpeciesGroups.Coleoptera, 
                Børstehale =  AlienSpeciesAssessment2023SpeciesGroups.Zygentoma,
                LusogLopper =    AlienSpeciesAssessment2023SpeciesGroups.Phthiraptera,
                Nebbmunner =    AlienSpeciesAssessment2023SpeciesGroups.Hemiptera,
                Sommerfugler = AlienSpeciesAssessment2023SpeciesGroups.Lepidoptera,
                Støvlus = AlienSpeciesAssessment2023SpeciesGroups.Psocoptera,
                Tovinger = AlienSpeciesAssessment2023SpeciesGroups.Diptera,
                Trips = AlienSpeciesAssessment2023SpeciesGroups.Thysanoptera,
                Vepser = AlienSpeciesAssessment2023SpeciesGroups.Hymenoptera
            };

    private static FilterAndMetaData AlienSpecies2023Insects() =>
            new()
            {
                Filters =
                Enum.GetValues<InsectSpeciesGroup>()
                .Select(x => new FilterItem
                {
                    NameShort = ((AlienSpeciesAssessment2023SpeciesGroups)x).ToString(),
                    Name = ((AlienSpeciesAssessment2023SpeciesGroups)x).DisplayName(),
                    Description = nameof(x),
                    InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/" + x.ToString().ToLower(),
                    ImageUrl = "https://design.artsdatabanken.no/icons/" + x.ToString() + ".svg",
                }).OrderBy(x => x.Name).ToArray(),
                FilterDescription = ""
            };

        public enum CrustaceanSpeciesGroup
        {
            Malacostraca = AlienSpeciesAssessment2023SpeciesGroups.Malacostraca,
            Branchiopoda = AlienSpeciesAssessment2023SpeciesGroups.Branchiopoda,
            Copepoda = AlienSpeciesAssessment2023SpeciesGroups.Copepoda,
            Thecostraca = AlienSpeciesAssessment2023SpeciesGroups.Thecostraca
        };

        private static FilterAndMetaData AlienSpecies2023Crustacean() =>
            new()
            {
                Filters =
                Enum.GetValues<CrustaceanSpeciesGroup>()
                .Select(x => new FilterItem
                {
                    NameShort = x.ToString(),
                    Name = ((AlienSpeciesAssessment2023SpeciesGroups)x).DisplayName(),
                    Description = nameof(x),
                    InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/" + x.ToString().ToLower(), //this url will probably never work (it use scientific name), but none of the urls with Norwegian names worked either as the pages don't exist for these species.. 
                    ImageUrl = "https://design.artsdatabanken.no/icons/Krepsdyr.svg",
                }).OrderBy(x => x.Name).ToArray(),
                FilterDescription = ""
            };

        
        public readonly FilterItem[] AlienSpecies2023SpeciesGroupsFilters =
        {
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Rhodophyta_Chlorophyta_Phaeophyceae.DisplayName(),
                NameShort = "sal",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                Description = "Rhodophyta, Chlorophyta, Phaeophyceae",
                SubGroup = AlienSpecies2023Algae()
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Amphibia.DisplayName(),
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Amphibia.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/amfibier",
                ImageUrl = "https://design.artsdatabanken.no/icons/Amfibier.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Amphibia)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Bacteria.DisplayName(),
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Bacteria.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bakterier",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bakterier.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Bacteria)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Mollusca.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Mollusca.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bl%c3%b8tdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bl%c3%b8tdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Mollusca)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Arachnida.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Arachnida.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/edderkoppdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Edderkoppdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Arachnida)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Oomycota.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Oomycota.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/eggsporesopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Eggsporesopper.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Oomycota)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Actinopterygii.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Actinopterygii.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/fisker",
                ImageUrl = "https://design.artsdatabanken.no/icons/Fisker.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Actinopterygii)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Platyhelminthes.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Platyhelminthes.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/flatormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Flatorm.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Platyhelminthes)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Aves.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Aves.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/fugler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Fugler.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Aves)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Pycnogonida.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Pycnogonida.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/havedderkopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Havedderkopper.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Pycnogonida)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Rotifera.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Rotifera.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/hjuldyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Hjuldyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Rotifera)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Insecta.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Insecta.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/insekter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Insekter.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Insecta),
                SubGroup = AlienSpecies2023Insects()
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Ctenophora.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Ctenophora.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Stormaneter.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Ctenophora)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Ascidiacea.DisplayName(),
                NameShort = "skd",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Sekkdyr.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Ascidiacea)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Tunicata)}"
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Magnoliophyta.DisplayName(),
                NameShort = "skp",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/karplanter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Karplanter.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Magnoliophyta)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Pinophyta)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Pteridophyta)}"
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Crustacea.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Crustacea.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/krepsdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Krepsdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Crustacea),
                SubGroup = AlienSpecies2023Crustacean()
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Annelida.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Annelida.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/leddormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Leddormer.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Annelida)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Myriapoda.DisplayName(),
                NameShort = "smf",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/mangefotinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Mangefotinger.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Myriapoda)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Chilopoda)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Diplopoda)}"
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Ectoprocta.DisplayName(),
                NameShort = "smb",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/mosdyrogbegerormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Mosdyr.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Ectoprocta)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Entoprocta)}"
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Bryophyta.DisplayName(),
                NameShort = "smo",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/moser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Moser.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Bryophyta)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Marchantiophyta)}"
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Cnidaria.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Cnidaria.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/nesledyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Nesledyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Cnidaria)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Mammalia.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Mammalia.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/pattedyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Pattedyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Mammalia)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Echinodermata.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Echinodermata.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/pigghuder",
                ImageUrl = "https://design.artsdatabanken.no/icons/Pigghuder.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Echinodermata)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Reptilia.DisplayName(), 
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Reptilia.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/reptiler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Reptiler.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Reptilia)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Nematoda.DisplayName(),
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Nematoda.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/rundormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Rundormer.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Nematoda)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Porifera.DisplayName(),
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Porifera.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/svamper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Svamper.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Porifera)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesGroups.Fungi.DisplayName(),
                NameShort = AlienSpeciesAssessment2023SpeciesGroups.Fungi.ToString(),
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/sopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Sopper.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Fungi)
            }
        };

        public FilterAndMetaData AlienSpecies2023SpeciesGroups() => 
            new()
            {
                Filters = AlienSpecies2023SpeciesGroupsFilters.OrderBy(x => x.Name).ToArray(),
                FilterDescription = "",
                FilterButtonName = "artsgruppefiltre",
                FilterButtonText = "Artsgrupper"
            };
    }

    public class Regions
    {
        public readonly FilterItem[] AlienSpecies2023RegionsFilters = Enum.GetValues<AlienSpeciesAssessment2023Region>()
            .Select(x => new FilterItem
            {
                Name = x.DisplayName(),
                NameShort = x.ToString()
            }).ToArray();

        public FilterAndMetaData AlienSpecies2023Regions() =>
            new()
            {
                Filters = AlienSpecies2023RegionsFilters,
                FilterDescription = "Regioner med kjent, antatt eller forventet forekomst",
                FilterButtonName = "regionfiltre",
                FilterButtonText = "Regioner og havområder"
            };
    }

    public class Habitat
    {
        public static readonly FilterItem[] AlienSpecies2023HabitatsFilters =
        {
            new()
            {
                Name = "Fastmarksskogsmark",
                NameShort = "Skog",
                ImageUrl = "https://data.artsdatabanken.no//Natur_i_Norge/Natursystem/Typeinndeling/Fastmarkssystemer/Fastmarksskogsmark/foto_408.jpg",
                Description = "Skogarealer, med unntak av treplantasjer, semi-naturlig eng som er tresatt og skog som påvirkes av flom.",
                Mapping = "Ensbetydende med NiN 2.0 hovedtypen <a href=\"https://artsdatabanken.no/Pages/171923/Fastmarksskogsmark\" target=\"_blank\" rel=\"noopener\">T4 Fastmarksskogsmark</a>."
            },
            new()
            {
                Name = "Ferskvannssystemer",
                NameShort = "Ferskvann",
                ImageUrl = "https://data.artsdatabanken.no//Natur_i_Norge/Natursystem/Typeinndeling/Limniske_vannmasser/foto_408.jpg",
                Description = "Samlebetegnelse på naturtyper i ferskvann.",
                Mapping = "Omfatter alle typene under NiN 2.0 hovedtypegruppene <a href=\"https://artsdatabanken.no/Pages/172024/Ferskvannsbunnsystemer\" target=\"_blank\" rel=\"noopener\">L Ferskvannsbunnsystemer</a> og <a href= \"https://artsdatabanken.no/Pages/172053/Limniske_vannmasser\" target =\"_blank\" rel=\"noopener\">F Limniske vannmasser</a>."
            },
            new()
            {
                Name = "Semi-naturlig fastmark",
                NameShort = "Semi-naturlig mark",
                ImageUrl = "https://data.artsdatabanken.no//Natur_i_Norge/Natursystem/Typeinndeling/Fastmarkssystemer/Kystlynghei/foto_408.jpg",
                Description = "Samlebetegnelse på åpne eller spredt tresatte fastmarkssystemer som er formet og betinget av tradisjonell hevd.",
                Mapping = "Omfatter NiN 2.0 hovedtypene <a href=\"https://artsdatabanken.no/Pages/171949/Boreal_hei\" target=\"_blank\" rel=\"noopener\">T31 Boreal hei</a>, <a href=\"//artsdatabanken.no/Pages/171950/Semi-naturlig_eng\" target=\"_blank\" rel=\"noopener\">T32 Semi-naturlig eng</a>, <a href=\"//artsdatabanken.no/Pages/171951/Semi-naturlig_strandeng\" target=\"_blank\" rel=\"noopener\">T33 Semi-naturlig strandeng</a> og <a href=\"//artsdatabanken.no/Pages/171952/Kystlynghei\" target=\"_blank\" rel=\"noopener\">T34 Kystlynghei</a>."
            },
            new()
            {
                Name = "Våtmarkssystemer",
                NameShort = "Våtmark",
                ImageUrl = "https://data.artsdatabanken.no//Natur_i_Norge/Natursystem/Typeinndeling/V%C3%A5tmarkssystemer/foto_408.jpg",
                Description = "Samlebetegnelse på myr, kilder og andre økosystmer på mer eller mindre vannmettet mark.",
                Mapping = "Omfatter alle hovedtypene under NiN 2.0 hovedtypegruppen <a href=\"https://artsdatabanken.no/Pages/172028/Vaatmarkssystemer\" target=\"_blank\" rel=\"noopener\">V Våtmarkssystemer</a>."
            }
        };

        public static readonly FilterAndMetaData AlienSpecies2023Habitats = new()
        {
            Filters = AlienSpecies2023HabitatsFilters,
            FilterDescription = "",
            FilterButtonName = "hovedhabitatfiltre",
            FilterButtonText = "Hovedhabitat"
        };
    }

    public class ProductionSpecies
    {
        public static readonly FilterItem[] AlienSpecies2023ProductionSpeciesFilters =
        {
            new FilterItem()
            {
                Name = "Tidligere eller nåværende bruksart",
                NameShort = true.ToString()
            },
            new FilterItem()
            {
                Name = "Ikke bruksart",
                NameShort = false.ToString()
            }
        };

        public static readonly FilterAndMetaData AlienSpecies2023ProductionSpecies = new()
        {
            Filters = AlienSpecies2023ProductionSpeciesFilters,
            FilterDescription = "",
            FilterButtonName = "'produksjonsart'-filtre",
            FilterButtonText = "Bruksart"
        };
    }

    public class SpeciesStatus
    {
        public static FilterAndMetaData AlienSpecies2023Doorknockers() =>
            new()
            {
                Filters =
                    Enum.GetValues<AlienSpeciesAssessment2023SpeciesStatus>().Where(x => x is not (AlienSpeciesAssessment2023SpeciesStatus.C3 or AlienSpeciesAssessment2023SpeciesStatus.C2 or AlienSpeciesAssessment2023SpeciesStatus.NotIndicated))
                    .Select(x => new FilterItem
                    {
                        Name = x.DisplayName(),
                        NameShort = x.ToString()
                    }).Reverse().ToArray()
                ,
                FilterDescription = ""
            };

        public readonly FilterItem[] AlienSpecies2023SpeciesStatusFilters =
        {
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesStatus.C3.DisplayName(),
                NameShort = nameof(AlienSpeciesAssessment2023SpeciesStatus.C3)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesStatus.C2.DisplayName(),
                NameShort = nameof(AlienSpeciesAssessment2023SpeciesStatus.C2)
            },
            new()
            {
                Name = "Dørstokkarter",
                NameShort = "eds",
                SubGroup = AlienSpecies2023Doorknockers()
            }
        };

        public FilterAndMetaData AlienSpecies2023SpeciesStatus() => 
            new()
            {
                Filters = AlienSpecies2023SpeciesStatusFilters,
                FilterDescription = "",
                FilterButtonName = "etableringsklassefiltre",
                FilterButtonText = "Etableringsstatus i dag"
            };
    }

    public class NotAssessed
    {
        public enum NotAssessedAlienSpeciesCategory
        {
            // ReSharper disable InconsistentNaming
            NotAlienSpecies = AlienSpeciecAssessment2023AlienSpeciesCategory.NotAlienSpecie,

            UncertainBefore1800 = AlienSpeciecAssessment2023AlienSpeciesCategory.UncertainBefore1800,

            MisIdentified = AlienSpeciecAssessment2023AlienSpeciesCategory.MisIdentified
        }

        public static FilterAndMetaData AlienSpecies2023NotAssessed() => 
            new()
            {
                Filters = Enum.GetValues<NotAssessedAlienSpeciesCategory>().Select(x => new FilterItem { Name = ((AlienSpeciecAssessment2023AlienSpeciesCategory) x).DisplayName(), NameShort = x.ToString() }).ToArray(),
                FilterDescription = "",
                FilterButtonName = "'ikke vurdert'-filtre",
                FilterButtonText = "Ikke-risikovurderte arter"
            };
    }
}
