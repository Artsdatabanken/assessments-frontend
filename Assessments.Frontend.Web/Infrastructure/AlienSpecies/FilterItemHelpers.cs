using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class Areas
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023AreasFilters = Enum.GetValues<AlienSpeciesAssessment2023EvaluationContext>()
            .Select(x => new Filter.FilterItem
            {
                Name = x.DisplayName(),
                NameShort = x.ToString()
            }).ToArray();

        public static readonly Filter.FilterAndMetaData AlienSpecies2023Areas = new()
        {
            Filters = AlienSpecies2023AreasFilters,
            FilterDescription = "",
            FilterButtonName = "områdefiltre",
            FilterButtonText = "Område"
        };
    }

    public class Categories
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023InvasionPotentialFilters = Enum.GetValues<AlienSpeciesAssessment2023MatrixAxisScore.InvasionPotential>()
            .Select(x => new Filter.FilterItem
            {
                NameShort = x.Description(),
                Name = x.DisplayName()
            }).Skip(1).ToArray();

        public static readonly Filter.FilterAndMetaData AlienSpecies2023InvasionPotential = new()
        {
            Filters = AlienSpecies2023InvasionPotentialFilters,
            FilterDescription = "Artens levedyktighet og evne til å ekspandere",
            FilterButtonName = "invasjonspotensialfiltre",
            FilterButtonText = "Invasjonspotensial (risikomatrisens x-akse)"
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023EcologicalEffectFilters = Enum.GetValues<AlienSpeciesAssessment2023MatrixAxisScore.EcologicalEffect>()
            .Select(x => new Filter.FilterItem
            {
                NameShort = x.Description(),
                Name = x.DisplayName()
            }).Skip(1).ToArray();

        public static readonly Filter.FilterAndMetaData AlienSpecies2023EcologicalEffect = new()
        {
            Filters = AlienSpecies2023EcologicalEffectFilters,
            FilterDescription = "Påvirkning på arter og naturtyper i Norge",
            FilterButtonName = "okologiskeffektfiltre",
            FilterButtonText = "Økologisk effekt (risikomatrisens y-akse)"
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023CategoriesFilters = Enum.GetValues<AlienSpeciesAssessment2023Category>()
            .Where(x => x != AlienSpeciesAssessment2023Category.NR)
            .Select(x => new Filter.FilterItem
            {
                NameShort = x.ToString(),
                Name = x.DisplayName(),
                Description = x.DisplayName()
            }).ToArray();

        public static readonly Filter.FilterAndMetaData AlienSpecies2023Categories = new()
        {
            Filters = AlienSpecies2023CategoriesFilters,
            FilterDescription = "",
            FilterButtonName = "kategorifiltre",
            FilterButtonText = "Risikokategori"
        };
    }

    public enum CategoryChangeEnum
    {
        // ReSharper disable InconsistentNaming
        [Display(Name = "Reell endring")]
        ccre,

        [Display(Name = "Ny kunnskap")]
        ccnk,

        [Display(Name = "Ny tolkning av tidligere data")]
        ccnt,

        [Display(Name = "Endrede avgrensninger eller retningslinjer")]
        ccea,

        [Display(Name = "Endret tolkning av retningslinjer")]
        ccet,

        [Display(Name = "Endret status (taksnonomi, til/fra stedegen)")]
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
                Name = CategoryChangeEnum.ccre.DisplayName(),
                NameShort = CategoryChangeEnum.ccre.ToString()
            },
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
        public enum DecisiveCriteriaEnum
        {
            [Display(Name = "A")]
            dcexa,

            [Display(Name = "B")]
            dcexb,

            [Display(Name = "AB")]
            dcipab,

            [Display(Name = "C")]
            dcipc,

            [Display(Name = "D")]
            dceed,

            [Display(Name = "E")]
            dcipe,

            [Display(Name = "F")]
            dceef,

            [Display(Name = "G")]
            dcipg,

            [Display(Name = "H")]
            dceeh,

            [Display(Name = "I")]
            dcipi,
        };

        public static readonly Filter.FilterItem[] ExistanceTimeAndExpansionSpeed =
        {
            new()
            {
                Name = "A – artens levetid i Norge",
                NameShort = nameof(DecisiveCriteriaEnum.dcexa)
            },
            new()
            {
                Name = "B – ekspansjonshastighet",
                NameShort = nameof(DecisiveCriteriaEnum.dcexb)
            }
        };

        public static readonly Filter.FilterItem[] InvationPotential =
        {
            new()
            {
                Name = "A×B – artens levetid i Norge × ekspansjonshastighet",
                NameShort = nameof(DecisiveCriteriaEnum.dcipab)
            },
            new()
            {
                Name = "A×B hvor høyeste skår er...",
                NameShort = "dcipah",
                SubGroup = new()
                {
                    Filters = ExistanceTimeAndExpansionSpeed,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = "C – kolonisert areal",
                NameShort = nameof(DecisiveCriteriaEnum.dcipc)
            }
        };

        public static readonly Filter.FilterItem[] EcologicalEffect =
        {
            new()
            {
                Name = "D – effekt på truede arter eller nøkkelarter",
                NameShort = nameof(DecisiveCriteriaEnum.dceed)
            },
            new()
            {
                Name = "E – effekt på øvrige arter",
                NameShort = nameof(DecisiveCriteriaEnum.dcipe)
            },
            new()
            {
                Name = "F – effekt på truede eller sjeldne naturtyper",
                NameShort = nameof(DecisiveCriteriaEnum.dceef)
            },
            new()
            {
                Name = "G – effekt på øvrige naturtyper",
                NameShort = nameof(DecisiveCriteriaEnum.dcipg)
            },
            new()
            {
                Name = "H – overføring av genetisk materiale",
                NameShort = nameof(DecisiveCriteriaEnum.dceeh)
            },
            new()
            {
                Name = "I – overføring av parasitter eller patogener",
                NameShort = nameof(DecisiveCriteriaEnum.dcipi)
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023DeciciveCriteriaFilters =
        {
            new()
            {
                Name = "Invasjonspotensial",
                NameShort = "dcin",
                SubGroup = new()
                {
                    Filters = InvationPotential,
                    FilterDescription = ""
                }
            },
            new()
            {
                Name = "Økologisk effekt",
                NameShort = "dcok",
                SubGroup = new()
                {
                    Filters = EcologicalEffect,
                    FilterDescription = ""
                }
            }
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023DeciciveCriteria = new()
        {
            Filters = AlienSpecies2023DeciciveCriteriaFilters,
            FilterDescription = "",
            FilterButtonName = "avgjorende kriterier-filtre",
            FilterButtonText = "Avgjørende kriterier for kategori"
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

            [Display(Name = "Taksonomisk nivå")]
            ttn,

            [Display(Name = "Vurderes på et annet taksonomisk nivå ")]
            tva,

            [Display(Name = "Vurderes ikke på et annet taksonomisk nivå ")]
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
            }
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
                ImageUrl = "https://design.artsdatabanken.no/icons/Storkrepser.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Malacostraca)
            },
            new()
            {
                Name = "Bladfotinger",
                NameShort = "sbf",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bladfotinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bladfotinger.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Branchiopoda)
            },
            new()
            {
                Name = "Hoppekreps",
                NameShort = "sho",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/copepoda",
                ImageUrl = "https://design.artsdatabanken.no/icons/Copepoda.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Copepoda)
            },
            new()
            {
                Name = "Rankefotinger",
                NameShort = "srf",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/thecostraca",
                ImageUrl = "https://design.artsdatabanken.no/icons/Thecostraca.svg",
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
                ImageUrl = "https://design.artsdatabanken.no/icons/Kammaneter.svg",
                Description = nameof(AlienSpeciesAssessment2023SpeciesGroups.Ctenophora)
            },
            new()
            {
                Name = "Kappedyr",
                NameShort = "skd",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Kammaneter.svg",
                Description = $"{nameof(AlienSpeciesAssessment2023SpeciesGroups.Ascidiacea)}, {nameof(AlienSpeciesAssessment2023SpeciesGroups.Tunicata)}"
            },
            new()
            {
                Name = "Karplanter",
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
        public static readonly Filter.FilterItem[] AlienSpecies2023RegionsFilters =
        {
            new()
            {
                Name = "Aust-Agder",
                NameShort = "AA"
            },
            new()
            {
                Name = "Buskerud",
                NameShort = "BU"
            },
            new()
            {
                Name = "Finnmark",
                NameShort = "FI"
            },
            new()
            {
                Name = "Hedmark",
                NameShort = "HE"
            },
            new()
            {
                Name = "Hordaland",
                NameShort = "HO"
            },
            new()
            {
                Name = "Jan Mayen",
                NameShort = "JM"
            },
            new()
            {
                Name = "Nordland",
                NameShort = "NO"
            },
            new()
            {
                Name = "Nord-Trøndelag",
                NameShort = "NT"
            },
            new()
            {
                Name = "Oppland",
                NameShort = "OP"
            },
            new()
            {
                Name = "Oslo og Akershus",
                NameShort = "OA"
            },
            new()
            {
                Name = "Rogaland",
                NameShort = "RO"
            },
            new()
            {
                Name = "Sogn og Fjordane",
                NameShort = "SF"
            },
            new()
            {
                Name = "Svalbard med sjøområder",
                NameShort = "SS"
            },
            new()
            {
                Name = "Sør-Trøndelag",
                NameShort = "ST"
            },
            new()
            {
                Name = "Telemark",
                NameShort = "TE"
            },
            new()
            {
                Name = "Troms",
                NameShort = "TR"
            },
            new()
            {
                Name = "Vest-Agder",
                NameShort = "VA"
            },
            new()
            {
                Name = "Vestfold",
                NameShort = "VF"
            },
            new()
            {
                Name = "ØstFold",
                NameShort = "ØF"
            },
            new()
            {
                Name = "Barentshavet nord og Polhavet",
                NameShort = "BP"
            },
            new()
            {
                Name = "Barentshavet sør",
                NameShort = "BS"
            },
            new()
            {
                Name = "Grønlandshavet",
                NameShort = "GH"
            },
            new()
            {
                Name = "Nordsjøen og Skagerrak",
                NameShort = "NS"
            },
            new()
            {
                Name = "Norskehavet",
                NameShort = "NH"
            },
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023Regions = new()
        {
            Filters = AlienSpecies2023RegionsFilters,
            FilterDescription = "",
            FilterButtonName = "regionfiltre",
            FilterButtonText = "Regioner og havområder"
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023WaterRegionsFilters =
        {
            new()
            {
                Name = "Agder",
                NameShort = "WAG"
            },
            new()
            {
                Name = "Bottenhavet",
                NameShort = "WBH"
            },
            new()
            {
                Name = "Bottenviken",
                NameShort = "WBV"
            },
            new()
            {
                Name = "Innlandet og Viken",
                NameShort = "WIV"
            },
            new()
            {
                Name = "Kemijoki",
                NameShort = "WKJ"
            },
            new()
            {
                Name = "Møre og Romsdal",
                NameShort = "WMR"
            },
            new()
            {
                Name = "Nordland og Jan Mayen",
                NameShort = "WNJ"
            },
            new()
            {
                Name = "Norsk-finsk",
                NameShort = "WNF"
            },
            new()
            {
                Name = "Rogaland",
                NameShort = "WRO"
            },
            new()
            {
                Name = "Torneå",
                NameShort = "WTO"
            },
            new()
            {
                Name = "Tornionjoki",
                NameShort = "WTJ"
            },
            new()
            {
                Name = "Troms og Finnmark",
                NameShort = "WTF"
            },
            new()
            {
                Name = "Trøndelag",
                NameShort = "WTR"
            },
            new()
            {
                Name = "Vestfold og Telemark",
                NameShort = "WVT"
            },
            new()
            {
                Name = "Vestland",
                NameShort = "WVE"
            },
            new()
            {
                Name = "Västerhavet",
                NameShort = "WVH"
            }
        };

        public static readonly Filter.FilterAndMetaData AlienSpecies2023WaterRegions = new()
        {
            Filters = AlienSpecies2023WaterRegionsFilters,
            FilterDescription = "",
            FilterButtonName = "vannregionfiltre",
            FilterButtonText = "Vannregioner"
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
            FilterButtonText = "Etableringsklasse i dag"
        };
    }
}
