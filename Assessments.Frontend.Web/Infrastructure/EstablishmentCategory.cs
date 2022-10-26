namespace Assessments.Frontend.Web.Infrastructure
{
    public class EstablishmentCategory
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023Doorknockers =
        {
            new Filter.FilterItem()
            {
                Name = "Overlever vinteren utendørs",
                NameShort = "eov"
            },
            new Filter.FilterItem()
            {
                Name = "Observert i norsk natur",
                NameShort = "eon"
            },
            new Filter.FilterItem()
            {
                Name = "Utendørs i eget produksjonsareal",
                NameShort = "eup"
            },
            new Filter.FilterItem()
            {
                Name = "Innendørs",
                NameShort = "eid"
            },
            new Filter.FilterItem()
            {
                Name = "Ikke i Norge",
                NameShort = "ein"
            }
        };

        public static readonly Filter.FilterItem[] AlienSpecies2023EstablishmentCategory =
        {
            new Filter.FilterItem()
            {
                Name = "Etablert",
                NameShort = "eet"
            },
            new Filter.FilterItem()
            {
                Name = "Selvstendig reproduserende",
                NameShort = "esr"
            },
            new Filter.FilterItem()
            {
                Name = "Dørstokkart",
                NameShort = "eda",
                SubGroup = AlienSpecies2023Doorknockers
            }
        };
    }
}
