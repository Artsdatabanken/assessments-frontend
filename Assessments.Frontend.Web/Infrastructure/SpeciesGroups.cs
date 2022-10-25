namespace Assessments.Frontend.Web.Infrastructure
{
    public class SpeciesGroups
    {
        // All NameShort for speciesGroup starts with 's' to not confuse them with other short names. 
        private static readonly Filter.FilterItem[] AlienSpecies2023Algae =
        {
            new Filter.FilterItem()
            {
                Name = "Brunagler",
                NameShort = "sbr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                Description = "Phaeophyceae"
            },
            new Filter.FilterItem()
            {
                Name = "Grønnalger",
                NameShort = "sga",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                Description = "Chlorophyta"
            },
            new Filter.FilterItem()
            {
                Name = "Rødalger",
                NameShort = "sra",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                Description = "Rhodophyta"
            }
        };

        private static readonly Filter.FilterItem[] AlienSpecies2023Insects =
        {
            new Filter.FilterItem()
            {
                Name = "Biller",
                NameShort = "sbi",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/biller",
                ImageUrl = "https://design.artsdatabanken.no/icons/Biller.svg",
                Description = "Coleoptera"
            },
            new Filter.FilterItem()
            {
                Name = "Børstehaler",
                NameShort = "sbo",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/b%c3%b8rstehaler",
                ImageUrl = "https://design.artsdatabanken.no/icons/B%c3%b8rstehale.svg",
                Description = "Zygentoma"
            },
            new Filter.FilterItem()
            {
                Name = "Knelere",
                NameShort = "skn",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/knelere",
                ImageUrl = "https://design.artsdatabanken.no/icons/Knelere.svg",
                Description = "Mantodea"
            },
            new Filter.FilterItem()
            {
                Name = "Lus og lopper",
                NameShort = "sll",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/lusoglopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/LusogLopper.svg",
                Description = "Phthiraptera og Siphonatera"
            },
            new Filter.FilterItem()
            {
                Name = "Nebbmunner",
                NameShort = "sne",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/nebbmunner",
                ImageUrl = "https://design.artsdatabanken.no/icons/Nebbmunner.svg",
                Description = "Hemiptera"
            },
            new Filter.FilterItem()
            {
                Name = "Rettvinger",
                NameShort = "srv",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/rettvinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Rettvinger.svg",
                Description = "Orthoptera"
            },
            new Filter.FilterItem()
            {
                Name = "Sommerfugler",
                NameShort = "ssf",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/sommerfugler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Sommerfugler.svg",
                Description = "Lepidoptera"
            },
            new Filter.FilterItem()
            {
                Name = "Støvlus",
                NameShort = "sst",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/st%c3%b8vlus",
                ImageUrl = "https://design.artsdatabanken.no/icons/St%c3%b8vlus.svg",
                Description = "Psocoptera"
            },
            new Filter.FilterItem()
            {
                Name = "Tovinger",
                NameShort = "sto",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/tovinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Tovinger.svg",
                Description = "Diptera"
            },
            new Filter.FilterItem()
            {
                Name = "Trips",
                NameShort = "str",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/trips",
                ImageUrl = "https://design.artsdatabanken.no/icons/Trips.svg",
                Description = "Thysanoptera"
            },
            new Filter.FilterItem()
            {
                Name = "Vepser",
                NameShort = "sve",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/vepser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Vepser.svg",
                Description = "Hymenoptera"
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023Crustacean =
        {
            new Filter.FilterItem()
            {
                Name = "Storkrepser",
                NameShort = "sst",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/storkrepser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Storkrepser.svg",
                Description = "Malacostraca"
            },
            new Filter.FilterItem()
            {
                Name = "Bladfotinger",
                NameShort = "sbl",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bladfotinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bladfotinger.svg",
                Description = "Branchiopoda"
            },
            new Filter.FilterItem()
            {
                Name = "Maxillopoda",
                NameShort = "sma",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/maxillopoda",
                ImageUrl = "https://design.artsdatabanken.no/icons/Maxillopoda.svg",
                Description = "Maxillopoda"
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023SpeciesGroups =
        {
            new Filter.FilterItem()
            {
                Name = "Alger",
                NameShort = "sal",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                Description = "Rhodophyta, Chlorophyta og Phaeophyceae",
                SubGroup = AlienSpecies2023Algae
            },
            new Filter.FilterItem()
            {
                Name = "Amfibier",
                NameShort = "sam",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/amfibier",
                ImageUrl = "https://design.artsdatabanken.no/icons/Amfibier.svg",
                Description = "Amphibia"
            },
            new Filter.FilterItem()
            {
                Name = "Bakterier",
                NameShort = "sba",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bakterier",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bakterier.svg",
                Description = "Bacteria"
            },
            new Filter.FilterItem()
            {
                Name = "Bløtdyr",
                NameShort = "sbl",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bl%c3%b8tdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bl%c3%b8tdyr.svg",
                Description = "Mollusca"
            },
            new Filter.FilterItem()
            {
                Name = "Edderkoppdyr",
                NameShort = "sed",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/edderkoppdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Edderkoppdyr.svg",
                Description = "Arachnida"
            },
            new Filter.FilterItem()
            {
                Name = "Eggsporesopper",
                NameShort = "seg",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/eggsporesopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Eggsporesopper.svg",
                Description = "Oomycota"
            },
            new Filter.FilterItem()
            {
                Name = "Fisker",
                NameShort = "sfi",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/fisker",
                ImageUrl = "https://design.artsdatabanken.no/icons/Fisker.svg",
                Description = "Actinopterygii"
            },
            new Filter.FilterItem()
            {
                Name = "Flatormer",
                NameShort = "sfl",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/flatormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Flatorm.svg",
                Description = "Actinopterygii"
            },
            new Filter.FilterItem()
            {
                Name = "Fugler",
                NameShort = "sfu",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/fugler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Fugler.svg",
                Description = "Aves"
            },
            new Filter.FilterItem()
            {
                Name = "Havedderkopper",
                NameShort = "sha",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/havedderkopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Havedderkopper.svg",
                Description = "Pycnogonida"
            },
            new Filter.FilterItem()
            {
                Name = "Hjuldyr",
                NameShort = "shj",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/hjuldyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Hjuldyr.svg",
                Description = "Rotifera"
            },
            new Filter.FilterItem()
            {
                Name = "Insekter",
                NameShort = "sin",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/insekter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Insekter.svg",
                Description = "Insecta",
                SubGroup = AlienSpecies2023Insects
            },
            new Filter.FilterItem()
            {
                Name = "Kammaneter",
                NameShort = "ska",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Kammaneter.svg",
                Description = "Ctenophora"
            },
            new Filter.FilterItem()
            {
                Name = "Kappedyr",
                NameShort = "skd",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Kammaneter.svg",
                Description = "Ascidiacea (Tunicata)"
            },
            new Filter.FilterItem()
            {
                Name = "Karplanter",
                NameShort = "skp",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Kammaneter.svg",
                Description = "Magnoliophyta, Pinophyta og Pteridophyta"
            },
            new Filter.FilterItem()
            {
                Name = "Krepsdyr",
                NameShort = "skr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/krepsdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Krepsdyr.svg",
                Description = "Crustacea",
                SubGroup = AlienSpecies2023Crustacean
            },
            new Filter.FilterItem()
            {
                Name = "Leddormer",
                NameShort = "sle",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/leddormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Leddormer.svg",
                Description = "Annelida"
            },
            new Filter.FilterItem()
            {
                Name = "Mangefotinger",
                NameShort = "smf",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/mangefotinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Mangefotinger.svg",
                Description = "Myriapoda [Chilopoda og Diplopoda]"
            },
            new Filter.FilterItem()
            {
                Name = "Mosdyr og begerormer",
                NameShort = "smb",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/mosdyrogbegerormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Mosdyr.svg",
                Description = "Ectoprocta og Entoprocta"
            },
            new Filter.FilterItem()
            {
                Name = "Moser",
                NameShort = "smo",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/moser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Moser.svg",
                Description = "Bryophyta og Marchantiophyta"
            },
            new Filter.FilterItem()
            {
                Name = "Nesledyr",
                NameShort = "snd",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/nesledyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Nesledyr.svg",
                Description = "Cnidaria"
            },
            new Filter.FilterItem()
            {
                Name = "Pigghuder",
                NameShort = "spi",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/pigghuder",
                ImageUrl = "https://design.artsdatabanken.no/icons/Pigghuder.svg",
                Description = "Echinodermata"
            },
            new Filter.FilterItem()
            {
                Name = "Reptiler",
                NameShort = "sre",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/reptiler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Reptiler.svg",
                Description = "Reptilia"
            },
            new Filter.FilterItem()
            {
                Name = "Rundormer",
                NameShort = "sru",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/rundormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Rundormer.svg",
                Description = "Nematoda"
            },
            new Filter.FilterItem()
            {
                Name = "Svamper",
                NameShort = "ssv",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/svamper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Svamper.svg",
                Description = "Porifera"
            },
            new Filter.FilterItem()
            {
                Name = "Sopper",
                NameShort = "sso",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/sopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Sopper.svg",
                Description = "Fungi"
            },
        };
    }
}
