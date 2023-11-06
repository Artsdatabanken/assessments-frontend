using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using Assessments.Shared.Resources.Enums.AlienSpecies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class Areas
    {
        private readonly Filter.FilterItem[] AlienSpecies2023AreasFilters = Enum.GetValues<AlienSpeciesAssessment2023EvaluationContext>()
            .Select(x => new Filter.FilterItem
            {
                Name = x.DisplayName(),
                NameShort = x.ToString()
            }).ToArray();

        public Filter.FilterAndMetaData AlienSpecies2023Areas() =>
            new()
            {
                Filters = AlienSpecies2023AreasFilters,
                FilterDescription = "",
                FilterButtonName = "områdefiltre",
                FilterButtonText = "Område"
            };
    }

    public class Categories
    {
        private readonly Filter.FilterItem[] AlienSpecies2023InvasionPotentialFilters = Enum.GetValues<AlienSpeciesAssessment2023MatrixAxisScore.InvasionPotential>()
            .Select(x => new Filter.FilterItem
            {
                NameShort = x.Description(),
                Name = x.DisplayName()
            }).Skip(1).ToArray();

        public Filter.FilterAndMetaData AlienSpecies2023InvasionPotential() =>
            new()
            {
                Filters = AlienSpecies2023InvasionPotentialFilters,
                FilterDescription = "Artens levedyktighet og evne til å ekspandere",
                FilterButtonName = "invasjonspotensialfiltre",
                FilterButtonText = "Invasjonspotensial (risikomatrisens x-akse)"
            };

        private readonly Filter.FilterItem[] AlienSpecies2023EcologicalEffectFilters = Enum.GetValues<AlienSpeciesAssessment2023MatrixAxisScore.EcologicalEffect>()
            .Select(x => new Filter.FilterItem
            {
                NameShort = x.Description(),
                Name = x.DisplayName()
            }).Skip(1).ToArray();

        public Filter.FilterAndMetaData AlienSpecies2023EcologicalEffect() => 
            new()
            {
                Filters = AlienSpecies2023EcologicalEffectFilters,
                FilterDescription = "Påvirkning på arter og naturtyper i Norge",
                FilterButtonName = "okologiskeffektfiltre",
                FilterButtonText = "Økologisk effekt (risikomatrisens y-akse)"
            };

        private readonly Filter.FilterItem[] _alienSpecies2023CategoriesFilters = Enum.GetValues<AlienSpeciesAssessment2023Category>()
            .Where(x => x != AlienSpeciesAssessment2023Category.NR)
            .Select(x => new Filter.FilterItem
            {
                NameShort = x.ToString(),
                Name = x.DisplayName(),
                Description = x.DisplayName()
            }).ToArray();

        public Filter.FilterAndMetaData AlienSpecies2023Categories() =>
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
        // ReSharper disable InconsistentNaming
        [Display(Name = "Ny kunnskap")]
        ccnk,

        [Display(Name = "Ny tolkning av tidligere data")]
        ccnt,

        [Display(Name = "Endrede avgrensninger eller retningslinjer")]
        ccea,

        [Display(Name = "Endret tolkning av retningslinjer")]
        ccet,

        [Display(Name = "Endret status (taksonomi, til/fra stedegen)")]
        cces,

        [Display(Name = "Vurdert for første gang")]
        ccvf,

        [Display(Name = "Kategorien er endret fra 2018")]
        ccke,

        [Display(Name = "Samme kategori som i 2018")]
        ccsk
    }

    public class CategoryChange
    {
        private static readonly Filter.FilterItem[] DifferFrom2018 =
        {
            new()
            {
                Name = CategoryChangeEnum.ccnk.DisplayName(),
                NameShort = CategoryChangeEnum.ccnk.ToString()
            },
            new()
            {
                Name = CategoryChangeEnum.ccnt.DisplayName(),
                NameShort = CategoryChangeEnum.ccnt.ToString()
            },
            new()
            {
                Name = CategoryChangeEnum.ccea.DisplayName(),
                NameShort = CategoryChangeEnum.ccea.ToString()
            },
            new()
            {
                Name = CategoryChangeEnum.ccet.DisplayName(),
                NameShort = CategoryChangeEnum.ccet.ToString()
            },
            new()
            {
                Name = CategoryChangeEnum.cces.DisplayName(),
                NameShort = CategoryChangeEnum.cces.ToString()
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023CategoryChangedFilters =
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
                SubGroup = new()
                {
                    Filters = DifferFrom2018,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = CategoryChangeEnum.ccsk.DisplayName(),
                NameShort = CategoryChangeEnum.ccsk.ToString()
            }
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023CategoryChanged = new()
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

        public static Filter.FilterAndMetaData MedianLifeTimeAndExpansionSpeed() =>
            new()
            {
                Filters = 
                    Enum.GetValues<DecisiveCriteriaInvasion>().Where(x => x is DecisiveCriteriaInvasion.A or DecisiveCriteriaInvasion.B)
                    .Select(x => new Filter.FilterItem
                    {
                        Name = x.ToString() + " - " + ((AlienSpeciesAssessment2023CriteriaLetter)x).DisplayName(),
                        NameShort = x.ToString()
                    }).ToArray()
                ,
                FilterDescription = ""
            };

        private static Filter.FilterAndMetaData InvationPotential() =>
           new()
           {
               Filters = Enum.GetValues<DecisiveCriteriaInvasion>().Where(x => x != DecisiveCriteriaInvasion.A & x != DecisiveCriteriaInvasion.B)
               .Select(x => new Filter.FilterItem
                   {
                        Name = x != DecisiveCriteriaInvasion.C ?  x.DisplayName()
                        : x.ToString() + " - " + ((AlienSpeciesAssessment2023CriteriaLetter)x).DisplayName(),
                        NameShort = x.ToString(),
                        SubGroup = x == DecisiveCriteriaInvasion.AxBdescribsion ? MedianLifeTimeAndExpansionSpeed() : null
                   }
               ).Reverse().ToArray(),
                   
               FilterDescription = "" 
           };

        public static Filter.FilterAndMetaData EcologicalEffect() =>
        new()
        {
            Filters = Enum.GetValues<DecisiveCriteriaEcologicalEffect>()
                    .Select(x => new Filter.FilterItem
                    {
                        Name = x.ToString() + " - " + ((AlienSpeciesAssessment2023CriteriaLetter) x).DisplayName(),
                        NameShort = x.ToString()
                    }).ToArray(),
            FilterDescription = ""
        };

        public readonly Filter.FilterItem[] AlienSpecies2023DeciciveCriteriaFilters =
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

        public Filter.FilterAndMetaData AlienSpecies2023DeciciveCriteria() =>
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

        public static readonly Filter.FilterItem[] AlienSpecies2023EnvironmentFilters =
        {
            new()
            {
                Name = nameof(AlienSpeciesAssessment2023Environment.Marint),
                NameShort = "Ema",
            },
            new()
            {
                Name = nameof(AlienSpeciesAssessment2023Environment.Limnisk),
                NameShort = "Eli",
            },
            new()
            {
                Name = nameof(AlienSpeciesAssessment2023Environment.Terrestrisk),
                NameShort = "Ete",
            }
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023Environment = new()
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

        public static readonly Filter.FilterItem[] AlienSpecies2023GeographicVariationFilters =
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

        public static readonly Filter.FilterAndMetaData AlienSpecies2023GeographicVariation = new()
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

        public static readonly Filter.FilterItem[] AlienSpecies2023ClimateEffectsFiltersAffected =
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

        public static readonly Filter.FilterItem[] AlienSpecies2023ClimateEffectsFiltersNotAffected =
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

        public static readonly Filter.FilterItem[] AlienSpecies2023ClimateEffectsFilters =
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

        public static readonly Filter.FilterAndMetaData AlienSpecies2023ClimateEffects = new()
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

        public static Filter.FilterAndMetaData AlienSpecies2023AlteredEcosystems() => 
            new()
            {
                Filters = Enum.GetValues<AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystems>()
                    .Select(x => new Filter.FilterItem
                    {
                        Name = x.DisplayName(),
                        NameShort = x.ToString()
                    }).ToArray(),
                FilterDescription = ""
            };

        public static Filter.FilterAndMetaData AlienSpecies2023AlteredMajorTypeGroupTypes() =>
            new()
            {
                Filters = Enum.GetValues<ImpactedNaturetypesThreatened>()
                    .Select(x => new Filter.FilterItem
                    {
                        Name = ((AlienSpeciesAssessment2023MajorTypeGroup)x).DisplayName(),
                        NameShort = x.ToString()
                    }).ToArray(),
                FilterDescription = ""
            };

        private readonly Filter.FilterItem[] AlienSpecies2023NatureTypesFilters =
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

        public Filter.FilterAndMetaData AlienSpecies2023NatureTypes() => 
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
            [Display(Name = "Direkte import")]
            Swidi,

            [Display(Name = "Som forurensning av vare")]
            Swifo,

            [Display(Name = "Som blindpassasjerer")]
            Swibl,

            [Display(Name = "Tilsiktet utsetting")]
            Swnbe,

            [Display(Name = "Rømning/forvilling")]
            Swnro,

            [Display(Name = "Som forurensning av vare")]
            Swnfo,

            [Display(Name = "Som blindpassasjerer")]
            Swnbl,

            [Display(Name = "Via menneskeskapt korridor")]
            Swnme,

            [Display(Name = "Egenspredning")]
            Swneg,

            [Display(Name = "Tilsiktet utsetting")]
            Swsti,

            [Display(Name = "Som forurensning av vare")]
            Swsfo,

            [Display(Name = "Som blindpassasjerer")]
            Swsbl,

            [Display(Name = "Via menneskeskapt korridor")]
            Swsme,

            [Display(Name = "Egenspredning")]
            Swseg,

            [Display(Name = "Import til produksjons- eller innendørsareal")]
            Swimp,

            [Display(Name = "Introduksjon til naturen")]
            Swnat,

            [Display(Name = "Spredning i naturen")]
            Swspr,
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023SpreadWaysFiltersImportPathways =
        {
            new ()
            {
                Name = SpreadWaysEnum.Swidi.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swidi),
            },
            new()
            {
                Name = SpreadWaysEnum.Swifo.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swifo),
            },
            new()
            {
                Name = SpreadWaysEnum.Swibl.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swibl),
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023SpreadWaysFiltersIntroduction =
        {
            new ()
            {
                Name = SpreadWaysEnum.Swnbe.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swnbe),
            },
            new()
            {
                Name = SpreadWaysEnum.Swnro.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swnro),
            },
            new()
            {
                Name = SpreadWaysEnum.Swnfo.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swnfo),
            },
            new()
            {
                Name = SpreadWaysEnum.Swnbl.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swnbl),
            },
            new()
            {
                Name = SpreadWaysEnum.Swnme.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swnme),
            },
            new()
            {
                Name = SpreadWaysEnum.Swneg.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swneg),
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023SpreadWaysFiltersSpread =
        {
            new ()
            {
                Name = SpreadWaysEnum.Swsti.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swsti),
            },
            new()
            {
                Name = SpreadWaysEnum.Swsfo.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swsfo),
            },
            new ()
            {
                Name = SpreadWaysEnum.Swsbl.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swsbl),
            },
            new()
            {
                Name = SpreadWaysEnum.Swsme.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swsme),
            },
            new()
            {
                Name = SpreadWaysEnum.Swseg.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swseg),
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023SpreadWaysFilters =
        {
            new ()
            {
                Name = SpreadWaysEnum.Swimp.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swimp),
                SubGroup = new()
                {
                    Filters = AlienSpecies2023SpreadWaysFiltersImportPathways,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = SpreadWaysEnum.Swnat.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swnat),
                SubGroup = new()
                {
                    Filters = AlienSpecies2023SpreadWaysFiltersIntroduction,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = SpreadWaysEnum.Swspr.DisplayName(),
                NameShort = nameof(SpreadWaysEnum.Swspr),
                SubGroup = new()
                {
                    Filters = AlienSpecies2023SpreadWaysFiltersSpread,
                    FilterDescription = ""
                }
            }
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023SpreadWays = new()
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

        public static readonly Filter.FilterItem[] RegionalSpread =
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

        public static readonly Filter.FilterItem[] AlienSpecies2023RegionallyAlienFilters =
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

        public static readonly Filter.FilterAndMetaData AlienSpecies2023RegionallyAlien = new()
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
            Art = 22,
            Underart = 23,
            Varietet = 24,
            Form = 25,

            [Display(Name = "Hybrid")]
            tth,

            [Display(Name = "Taksonomisk nivå")]
            ttn,

            [Display(Name = nameof(AlienSpeciesAssessment2023AlienSpeciesCategoryResource.evaluated_at_another_level), ResourceType = typeof(AlienSpeciesAssessment2023AlienSpeciesCategoryResource))]
            tva,

            [Display(Name = "Vurderes ikke på et annet taksonomisk nivå")]
            tvi
        }

        public static readonly Filter.FilterItem[] TaxonRanks2023 =
        {
            new()
            {
                Name = nameof(TaxonRankEnum.Art),
                NameShort = TaxonRankEnum.Art.GetHashCode().ToString()
            },
            new()
            {
            Name = TaxonRankEnum.tth.DisplayName(),
            NameShort = TaxonRankEnum.tth.ToString()
            },
            new()
            {
                Name = nameof(TaxonRankEnum.Underart),
                NameShort = TaxonRankEnum.Underart.GetHashCode().ToString()
            },
            new()
            {
                Name = nameof(TaxonRankEnum.Varietet),
                NameShort = TaxonRankEnum.Varietet.GetHashCode().ToString()
            },
            new()
            {
            Name = nameof(TaxonRankEnum.Form),
            NameShort = TaxonRankEnum.Form.GetHashCode().ToString()
            },
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023TaxonRanksFilters =
        {
            new()
            {
                Name = TaxonRankEnum.ttn.DisplayName(),
                NameShort = TaxonRankEnum.ttn.ToString(),
                SubGroup = new()
                {
                    Filters = TaxonRanks2023,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = TaxonRankEnum.tva.DisplayName(),
                NameShort = TaxonRankEnum.tva.ToString()
            },
            new()
            {
                Name = TaxonRankEnum.tvi.DisplayName(),
                NameShort = TaxonRankEnum.tvi.ToString()
            }
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023TaxonRanks = new()
        {
            Filters = AlienSpecies2023TaxonRanksFilters,
            FilterDescription = "",
            FilterButtonName = "'taksonomisk nivå'-filtre",
            FilterButtonText = "Taksonomi"
        };
    }

    public class SpeciesGroups
    {
        // All NameShort for speciesGroup starts with 's' to not confuse them with other short names. 
        private static readonly Filter.FilterItem[] AlienSpecies2023Algae =
        {
            new()
            {
                Name = "Brunalger",
                NameShort = "sbr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Phaeophyceae)
            },
            new()
            {
                Name = "Grønnalger",
                NameShort = "sga",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Chlorophyta)
            },
            new()
            {
                Name = "Rødalger",
                NameShort = "sra",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Rhodophyta)
            }
        };

        private static readonly Filter.FilterItem[] AlienSpecies2023Insects =
        {
            new()
            {
                Name = "Biller",
                NameShort = "sbi",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/biller",
                ImageUrl = "https://design.artsdatabanken.no/icons/Biller.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Coleoptera)
            },
            new()
            {
                Name = "Børstehaler",
                NameShort = "sbo",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/b%c3%b8rstehaler",
                ImageUrl = "https://design.artsdatabanken.no/icons/B%c3%b8rstehale.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Zygentoma)
            },
            new()
            {
                Name = "Lus",
                NameShort = "sll",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/lusoglopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/LusogLopper.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Phthiraptera)}"
            },
            new()
            {
                Name = "Nebbmunner",
                NameShort = "sne",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/nebbmunner",
                ImageUrl = "https://design.artsdatabanken.no/icons/Nebbmunner.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Hemiptera)
            },
            new()
            {
                Name = "Sommerfugler",
                NameShort = "ssf",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/sommerfugler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Sommerfugler.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Lepidoptera)
            },
            new()
            {
                Name = "Støvlus",
                NameShort = "ssl",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/st%c3%b8vlus",
                ImageUrl = "https://design.artsdatabanken.no/icons/St%c3%b8vlus.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Psocoptera)
            },
            new()
            {
                Name = "Tovinger",
                NameShort = "sto",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/tovinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Tovinger.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Diptera)
            },
            new()
            {
                Name = "Trips",
                NameShort = "str",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/trips",
                ImageUrl = "https://design.artsdatabanken.no/icons/Trips.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Thysanoptera)
            },
            new()
            {
                Name = "Vepser",
                NameShort = "sve",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/vepser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Vepser.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Hymenoptera)
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023Crustacean =
        {
            new()
            {
                Name = "Storkrepser",
                NameShort = "sst",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/storkrepser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Krepsdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Malacostraca)
            },
            new()
            {
                Name = "Bladfotinger",
                NameShort = "sbf",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bladfotinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Krepsdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Branchiopoda)
            },
            new()
            {
                Name = "Hoppekreps",
                NameShort = "sho",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/copepoda",
                ImageUrl = "https://design.artsdatabanken.no/icons/Krepsdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Copepoda)
            },
            new()
            {
                Name = "Rankefotinger",
                NameShort = "srf",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/thecostraca",
                ImageUrl = "https://design.artsdatabanken.no/icons/Krepsdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Thecostraca)
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023SpeciesGroupsFilters =
        {
            new()
            {
                Name = "Alger",
                NameShort = "sal",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                Description = "Rhodophyta, Chlorophyta, Phaeophyceae",
                SubGroup = new()
                {
                    Filters = AlienSpecies2023Algae,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = "Amfibier",
                NameShort = "sam",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/amfibier",
                ImageUrl = "https://design.artsdatabanken.no/icons/Amfibier.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Amphibia)
            },
            new()
            {
                Name = "Bakterier",
                NameShort = "sba",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bakterier",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bakterier.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Bacteria)
            },
            new()
            {
                Name = "Bløtdyr",
                NameShort = "sbl",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bl%c3%b8tdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bl%c3%b8tdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Mollusca)
            },
            new()
            {
                Name = "Edderkoppdyr",
                NameShort = "sed",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/edderkoppdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Edderkoppdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Arachnida)
            },
            new()
            {
                Name = "Eggsporesopper",
                NameShort = "seg",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/eggsporesopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Eggsporesopper.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Oomycota)
            },
            new()
            {
                Name = "Fisker",
                NameShort = "sfi",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/fisker",
                ImageUrl = "https://design.artsdatabanken.no/icons/Fisker.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Actinopterygii)
            },
            new()
            {
                Name = "Flatormer",
                NameShort = "sfl",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/flatormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Flatorm.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Platyhelminthes)
            },
            new()
            {
                Name = "Fugler",
                NameShort = "sfu",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/fugler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Fugler.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Aves)
            },
            new()
            {
                Name = "Havedderkopper",
                NameShort = "sha",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/havedderkopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Havedderkopper.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Pycnogonida)
            },
            new()
            {
                Name = "Hjuldyr",
                NameShort = "shj",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/hjuldyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Hjuldyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Rotifera)
            },
            new()
            {
                Name = "Insekter",
                NameShort = "sin",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/insekter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Insekter.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Insecta),
                SubGroup = new()
                {
                    Filters = AlienSpecies2023Insects,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = "Kammaneter",
                NameShort = "ska",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Stormaneter.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Ctenophora)
            },
            new()
            {
                Name = "Kappedyr",
                NameShort = "skd",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Sekkdyr.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Ascidiacea)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Tunicata)}"
            },
            new()
            {
                Name = "Planter",
                NameShort = "skp",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/karplanter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Karplanter.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Magnoliophyta)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Pinophyta)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Pteridophyta)}"
            },
            new()
            {
                Name = "Krepsdyr",
                NameShort = "skr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/krepsdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Krepsdyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Crustacea),
                SubGroup = new()
                {
                    Filters = AlienSpecies2023Crustacean,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = "Leddormer",
                NameShort = "sle",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/leddormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Leddormer.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Annelida)
            },
            new()
            {
                Name = "Mangefotinger",
                NameShort = "smf",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/mangefotinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Mangefotinger.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Myriapoda)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Chilopoda)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Diplopoda)}"
            },
            new()
            {
                Name = "Mosdyr og begerormer",
                NameShort = "smb",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/mosdyrogbegerormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Mosdyr.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Ectoprocta)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Entoprocta)}"
            },
            new()
            {
                Name = "Moser",
                NameShort = "smo",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/moser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Moser.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Bryophyta)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Marchantiophyta)}"
            },
            new()
            {
                Name = "Nesledyr",
                NameShort = "snd",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/nesledyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Nesledyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Cnidaria)
            },
            new()
            {
                Name = "Pattedyr",
                NameShort = "spd",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/pattedyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Pattedyr.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Mammalia)
            },
            new()
            {
                Name = "Pigghuder",
                NameShort = "spi",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/pigghuder",
                ImageUrl = "https://design.artsdatabanken.no/icons/Pigghuder.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Echinodermata)
            },
            new()
            {
                Name = "Reptiler",
                NameShort = "sre",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/reptiler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Reptiler.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Reptilia)
            },
            new()
            {
                Name = "Rundormer",
                NameShort = "sru",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/rundormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Rundormer.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Nematoda)
            },
            new()
            {
                Name = "Svamper",
                NameShort = "ssv",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/svamper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Svamper.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Porifera)
            },
            new()
            {
                Name = "Sopper",
                NameShort = "sso",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/sopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Sopper.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Fungi)
            }
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023SpeciesGroups = new()
        {
            Filters = AlienSpecies2023SpeciesGroupsFilters,
            FilterDescription = "",
            FilterButtonName = "artsgruppefiltre",
            FilterButtonText = "Artsgrupper"
        };
    }

    public class Regions
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023RegionsFilters = Enum.GetValues<AlienSpeciesAssessment2023Region>()
            .Select(x => new Filter.FilterItem
            {
                Name = x.DisplayName(),
                NameShort = x.ToString()
            }).ToArray();

        public static readonly Filter.FilterAndMetaData AlienSpecies2023Regions = new()
        {
            Filters = AlienSpecies2023RegionsFilters,
            FilterDescription = "Regioner med kjent, antatt eller forventet forekomst",
            FilterButtonName = "regionfiltre",
            FilterButtonText = "Regioner og havområder"
        };
    }

    public class Habitat
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023HabitatsFilters =
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

        public static readonly Filter.FilterAndMetaData AlienSpecies2023Habitats = new()
        {
            Filters = AlienSpecies2023HabitatsFilters,
            FilterDescription = "",
            FilterButtonName = "hovedhabitatfiltre",
            FilterButtonText = "Hovedhabitat"
        };
    }

    public class ProductionSpecies
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023ProductionSpeciesFilters =
        {
            new Filter.FilterItem()
            {
                Name = "Tidligere eller nåværende bruksart",
                NameShort = true.ToString()
            },
            new Filter.FilterItem()
            {
                Name = "Ikke bruksart",
                NameShort = false.ToString()
            }
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023ProductionSpecies = new()
        {
            Filters = AlienSpecies2023ProductionSpeciesFilters,
            FilterDescription = "",
            FilterButtonName = "'produksjonsart'-filtre",
            FilterButtonText = "Bruksart"
        };
    }

    public class SpeciesStatus
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023Doorknockers =
        {
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesStatus.C1.DisplayName(),
                NameShort = nameof(AlienSpeciesAssessment2023SpeciesStatus.C1)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesStatus.C0.DisplayName(),
                NameShort = nameof(AlienSpeciesAssessment2023SpeciesStatus.C0)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesStatus.B2.DisplayName(),
                NameShort = nameof(AlienSpeciesAssessment2023SpeciesStatus.B2)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesStatus.B1.DisplayName(),
                NameShort = nameof(AlienSpeciesAssessment2023SpeciesStatus.B1)
            },
            new()
            {
                Name = AlienSpeciesAssessment2023SpeciesStatus.A.DisplayName(),
                NameShort = nameof(AlienSpeciesAssessment2023SpeciesStatus.A)
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023SpeciesStatusFilters =
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
                SubGroup = new()
                {
                    Filters = AlienSpecies2023Doorknockers,
                    FilterDescription = ""
                }
            }
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023SpeciesStatus = new()
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

        public static Filter.FilterAndMetaData AlienSpecies2023NotAssessed() => 
            new()
            {
                Filters = Enum.GetValues<NotAssessedAlienSpeciesCategory>().Select(x => new Filter.FilterItem { Name = ((AlienSpeciecAssessment2023AlienSpeciesCategory) x).DisplayName(), NameShort = x.ToString() }).ToArray(),
                FilterDescription = "",
                FilterButtonName = "'ikke vurdert'-filtre",
                FilterButtonText = "Ikke-risikovurderte arter"
            };
    }
}
