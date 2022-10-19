using DocumentFormat.OpenXml.Wordprocessing;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class Habitat
    {
        public class HabitatItem
        {
            public string Name { get; set; }

            public string ShortName { get; set; }

            public string ImageUrl { get; set; }

            public string Description { get; set; }

            public string Mapping { get; set; }
        }

        public static readonly HabitatItem[] AlienSpecies2023Habitats =
        {
            new HabitatItem()
            {
                Name = "Fastmarksskogsmark",
                ShortName = "Skog",
                ImageUrl = "https://data.artsdatabanken.no//Natur_i_Norge/Natursystem/Typeinndeling/Fastmarkssystemer/Fastmarksskogsmark/foto_408.jpg",
                Description = "Skogarealer, med unntak av treplantasjer, semi-naturlig eng som er tresatt og skog som påvirkes av flom.",
                Mapping = "Ensbetydende med NiN 2.0 hovedtypen <a href=\"https://artsdatabanken.no/Pages/171923/Fastmarksskogsmark\" target=\"_new\" rel=\"noopener\">T4 Fastmarksskogsmark</a>."
            },
            new HabitatItem()
            {
                Name = "Ferskvannssystemer",
                ShortName = "Ferskvann",
                ImageUrl = "https://data.artsdatabanken.no//Natur_i_Norge/Natursystem/Typeinndeling/Limniske_vannmasser/foto_408.jpg",
                Description = "Samlebetegnelse på naturtyper i ferskvann.",
                Mapping = "Omfatter alle typene under NiN 2.0 hovedtypegruppene <a href=\"https://artsdatabanken.no/Pages/172024/Ferskvannsbunnsystemer\" target=\"_new\" rel=\"noopener\">L Ferskvannsbunnsystemer</a> og <a href= \"https://artsdatabanken.no/Pages/172053/Limniske_vannmasser\" target =\"_new\" rel=\"noopener\">F Limniske vannmasser</a>."
            },
            new HabitatItem()
            {
                Name = "Semi-naturlig fastmark",
                ShortName = "Semi-naturlig mark",
                ImageUrl = "https://data.artsdatabanken.no//Natur_i_Norge/Natursystem/Typeinndeling/Fastmarkssystemer/Kystlynghei/foto_408.jpg",
                Description = "Samlebetegnelse på åpne eller spredt tresatte fastmarkssystemer som er formet og betinget av tradisjonell hevd.",
                Mapping = "Omfatter NiN 2.0 hovedtypene <a href=\"https://artsdatabanken.no/Pages/171949/Boreal_hei\" target=\"_new\" rel=\"noopener\">T31 Boreal hei</a>, <a href=\"//artsdatabanken.no/Pages/171950/Semi-naturlig_eng\" target=\"_new\" rel=\"noopener\">T32 Semi-naturlig eng</a>, <a href=\"//artsdatabanken.no/Pages/171951/Semi-naturlig_strandeng\" target=\"_new\" rel=\"noopener\">T33 Semi-naturlig strandeng</a> og <a href=\"//artsdatabanken.no/Pages/171952/Kystlynghei\" target=\"_new\" rel=\"noopener\">T34 Kystlynghei</a>."
            },
            new HabitatItem()
            {
                Name = "Våtmarkssystemer",
                ShortName = "Våtmark",
                ImageUrl = "https://data.artsdatabanken.no//Natur_i_Norge/Natursystem/Typeinndeling/V%C3%A5tmarkssystemer/foto_408.jpg",
                Description = "Samlebetegnelse på myr, kilder og andre økosystmer på mer eller mindre vannmettet mark.",
                Mapping = "Omfatter alle hovedtypene under NiN 2.0 hovedtypegruppen <a href=\"https://artsdatabanken.no/Pages/172028/Vaatmarkssystemer\" target=\"_new\" rel=\"noopener\">V Våtmarkssystemer</a>."
            }
        };
    }
}
