namespace Assessments.Frontend.Web.Infrastructure
{
    public class SpeciesGroups
    {
        public class SpeciesGroupItem
        {
            public string SpeciesName { get; set; }

            public string InfoUrl { get; set; }

            public string ImageUrl { get; set; }

            public string TagLine { get; set; }

            public SpeciesGroupItem[] SubGroup { get; set; }
        }

        private static readonly SpeciesGroupItem[] AlienSpecies2023Algae =
        {
            new SpeciesGroupItem()
            {
                SpeciesName = "Brunagler",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                TagLine = "Phaeophyceae"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Grønnalger",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                TagLine = "Chlorophyta"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Rødalger",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                TagLine = "Rhodophyta"
            }
        };

        private static readonly SpeciesGroupItem[] AlienSpecies2023Insects =
        {
            new SpeciesGroupItem()
            {
                SpeciesName = "Biller",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/biller",
                ImageUrl = "https://design.artsdatabanken.no/icons/Biller.svg",
                TagLine = "Coleoptera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Børstehaler",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/b%c3%b8rstehaler",
                ImageUrl = "https://design.artsdatabanken.no/icons/B%c3%b8rstehale.svg",
                TagLine = "Zygentoma"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Knelere",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/knelere",
                ImageUrl = "https://design.artsdatabanken.no/icons/Knelere.svg",
                TagLine = "Mantodea"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Lus og lopper",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/lusoglopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/LusogLopper.svg",
                TagLine = "Phthiraptera og Siphonatera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Nebbmunner",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/nebbmunner",
                ImageUrl = "https://design.artsdatabanken.no/icons/Nebbmunner.svg",
                TagLine = "Hemiptera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Rettvinger",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/rettvinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Rettvinger.svg",
                TagLine = "Orthoptera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Sommerfugler",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/sommerfugler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Sommerfugler.svg",
                TagLine = "Lepidoptera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Støvlus",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/st%c3%b8vlus",
                ImageUrl = "https://design.artsdatabanken.no/icons/St%c3%b8vlus.svg",
                TagLine = "Psocoptera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Tovinger",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/tovinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Tovinger.svg",
                TagLine = "Diptera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Trips",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/trips",
                ImageUrl = "https://design.artsdatabanken.no/icons/Trips.svg",
                TagLine = "Thysanoptera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Vepser",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/vepser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Vepser.svg",
                TagLine = "Hymenoptera"
            }
        };

        public static readonly SpeciesGroupItem[] AlienSpecies2023Crustacean =
        {
            new SpeciesGroupItem()
            {
                SpeciesName = "Storkrepser",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/storkrepser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Storkrepser.svg",
                TagLine = "Malacostraca"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Bladfotinger",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bladfotinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bladfotinger.svg",
                TagLine = "Branchiopoda"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Maxillopoda",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/maxillopoda",
                ImageUrl = "https://design.artsdatabanken.no/icons/Maxillopoda.svg",
                TagLine = "Maxillopoda"
            }
        };

        public static readonly SpeciesGroupItem[] AlienSpecies2023SpeciesGroups =
        {
            new SpeciesGroupItem()
            {
                SpeciesName = "Alger",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/alger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Alger.svg",
                TagLine = "Rhodophyta, Chlorophyta og Phaeophyceae",
                SubGroup = AlienSpecies2023Algae
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Amfibier",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/amfibier",
                ImageUrl = "https://design.artsdatabanken.no/icons/Amfibier.svg",
                TagLine = "Amphibia"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Bakterier",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bakterier",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bakterier.svg",
                TagLine = "Bacteria"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Bløtdyr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/bl%c3%b8tdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Bl%c3%b8tdyr.svg",
                TagLine = "Mollusca"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Edderkoppdyr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/edderkoppdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Edderkoppdyr.svg",
                TagLine = "Arachnida"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Eggsporesopper",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/eggsporesopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Eggsporesopper.svg",
                TagLine = "Oomycota"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Fisker",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/fisker",
                ImageUrl = "https://design.artsdatabanken.no/icons/Fisker.svg",
                TagLine = "Actinopterygii"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Flatormer",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/flatormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Flatorm.svg",
                TagLine = "Actinopterygii"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Fugler",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/fugler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Fugler.svg",
                TagLine = "Aves"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Havedderkopper",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/havedderkopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Havedderkopper.svg",
                TagLine = "Pycnogonida"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Hjuldyr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/hjuldyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Hjuldyr.svg",
                TagLine = "Rotifera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Insekter",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/insekter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Insekter.svg",
                TagLine = "Insecta",
                SubGroup = AlienSpecies2023Insects
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Kammaneter",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Kammaneter.svg",
                TagLine = "Ctenophora"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Kappedyr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Kammaneter.svg",
                TagLine = "Ascidiacea (Tunicata)"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Karplanter",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/kammaneter",
                ImageUrl = "https://design.artsdatabanken.no/icons/Kammaneter.svg",
                TagLine = "Magnoliophyta, Pinophyta og Pteridophyta"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Krepsdyr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/krepsdyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Krepsdyr.svg",
                TagLine = "Crustacea",
                SubGroup = AlienSpecies2023Crustacean
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Leddormer",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/leddormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Leddormer.svg",
                TagLine = "Annelida"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Mangefotinger",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/mangefotinger",
                ImageUrl = "https://design.artsdatabanken.no/icons/Mangefotinger.svg",
                TagLine = "Myriapoda [Chilopoda og Diplopoda]"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Mosdyr og begerormer",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/mosdyrogbegerormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Mosdyr.svg",
                TagLine = "Ectoprocta og Entoprocta"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Moser",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/moser",
                ImageUrl = "https://design.artsdatabanken.no/icons/Moser.svg",
                TagLine = "Bryophyta og Marchantiophyta"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Nesledyr",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/nesledyr",
                ImageUrl = "https://design.artsdatabanken.no/icons/Nesledyr.svg",
                TagLine = "Cnidaria"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Pigghuder",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/pigghuder",
                ImageUrl = "https://design.artsdatabanken.no/icons/Pigghuder.svg",
                TagLine = "Echinodermata"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Reptiler",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/reptiler",
                ImageUrl = "https://design.artsdatabanken.no/icons/Reptiler.svg",
                TagLine = "Reptilia"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Rundormer",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/rundormer",
                ImageUrl = "https://design.artsdatabanken.no/icons/Rundormer.svg",
                TagLine = "Nematoda"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Svamper",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/svamper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Svamper.svg",
                TagLine = "Porifera"
            },
            new SpeciesGroupItem()
            {
                SpeciesName = "Sopper",
                InfoUrl = "https://artsdatabanken.no/fremmedartsliste2023/Artsgruppene/sopper",
                ImageUrl = "https://design.artsdatabanken.no/icons/Sopper.svg",
                TagLine = "Fungi"
            },
        };
    }
}
