namespace Assessments.Frontend.Web.Infrastructure
{
    public class ProductionSpecies
    {
        public static Filter.FilterItem[] AlienSpecies2023ProductionSpecies =
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
    }
}
