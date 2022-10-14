using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class Regoins
    {
        public class RegionItem
        {
            public string RegionName { get; set; }

            public string RegionShortName { get; set; }
        }

        public static readonly RegionItem[] AlienSpecies2023Regions =
        {
            new RegionItem()
            { 
                RegionName = "Aust-Agder",
                RegionShortName = "AA"
            },
            new RegionItem()
            {
                RegionName = "Buskerud",
                RegionShortName = "BU"
            },
            new RegionItem()
            {
                RegionName = "Finnmark",
                RegionShortName = "FI"
            },
            new RegionItem()
            {
                RegionName = "Hedmark",
                RegionShortName = "HE"
            },
            new RegionItem()
            {
                RegionName = "Hordaland",
                RegionShortName = "HO"
            },
            new RegionItem()
            {
                RegionName = "Jan Mayen",
                RegionShortName = "JM"
            },
            new RegionItem()
            {
                RegionName = "Nordland",
                RegionShortName = "NO"
            },
            new RegionItem()
            {
                RegionName = "Nord-Trøndelag",
                RegionShortName = "NT"
            },
            new RegionItem()
            {
                RegionName = "Oppland",
                RegionShortName = "OP"
            },
            new RegionItem()
            {
                RegionName = "Oslo og Akershus",
                RegionShortName = "OA"
            },
            new RegionItem()
            {
                RegionName = "Rogaland",
                RegionShortName = "RO"
            },
            new RegionItem()
            {
                RegionName = "Sogn og Fjordane",
                RegionShortName = "SF"
            },
            new RegionItem()
            {
                RegionName = "Svalbard med sjøområder",
                RegionShortName = "SS"
            },
            new RegionItem()
            {
                RegionName = "Sør-Trøndelag",
                RegionShortName = "ST"
            },
            new RegionItem()
            {
                RegionName = "Telemark",
                RegionShortName = "TE"
            },
            new RegionItem()
            {
                RegionName = "Troms",
                RegionShortName = "TR"
            },
            new RegionItem()
            {
                RegionName = "Vest-Agder",
                RegionShortName = "VA"
            },
            new RegionItem()
            {
                RegionName = "Vestfold",
                RegionShortName = "VF"
            },
            new RegionItem()
            {
                RegionName = "ØstFold",
                RegionShortName = "ØF"
            },
            new RegionItem()
            {
                RegionName = "Barentshavet nord og Polhavet",
                RegionShortName = "BP"
            },
            new RegionItem()
            {
                RegionName = "Barentshavet sør",
                RegionShortName = "BS"
            },
            new RegionItem()
            {
                RegionName = "Grønlandshavet",
                RegionShortName = "GH"
            },
            new RegionItem()
            {
                RegionName = "Nordsjøen og Skagerrak",
                RegionShortName = "NS"
            },
            new RegionItem()
            {
                RegionName = "Norskehavet",
                RegionShortName = "NH"
            },
        };

        public static readonly RegionItem[] AlienSpecies2023WaterRegions =
        {
            new RegionItem()
            {
                RegionName = "Agder",
                RegionShortName = "WAG"
            },
            new RegionItem()
            {
                RegionName = "Bottenhavet",
                RegionShortName = "WBH"
            }, 
            new RegionItem()
            {
                RegionName = "Bottenviken",
                RegionShortName = "WBV"
            },
            new RegionItem()
            {
                RegionName = "Innlandet og Viken",
                RegionShortName = "WIV"
            },
            new RegionItem()
            {
                RegionName = "Kemijoki",
                RegionShortName = "WKJ"
            },
            new RegionItem()
            {
                RegionName = "Møre og Romsdal",
                RegionShortName = "WMR"
            },
            new RegionItem()
            {
                RegionName = "Nordland og Jan Mayen",
                RegionShortName = "WNJ"
            },
            new RegionItem()
            {
                RegionName = "Norsk-finsk",
                RegionShortName = "WNF"
            },
            new RegionItem()
            {
                RegionName = "Rogaland",
                RegionShortName = "WRO"
            }, 
            new RegionItem()
            {
                RegionName = "Torneå",
                RegionShortName = "WTO"
            },
            new RegionItem()
            {
                RegionName = "Tornionjoki",
                RegionShortName = "WTJ"
            }, 
            new RegionItem()
            {
                RegionName = "Troms og Finnmark",
                RegionShortName = "WTF"
            },
            new RegionItem()
            {
                RegionName = "Trøndelag",
                RegionShortName = "WTR"
            },
            new RegionItem()
            {
                RegionName = "Vestfold og Telemark",
                RegionShortName = "WVT"
            },
            new RegionItem()
            {
                RegionName = "Vestland",
                RegionShortName = "WVE"
            }, 
            new RegionItem()
            {
                RegionName = "Västerhavet",
                RegionShortName = "WVH"
            },
        };
    }
}
