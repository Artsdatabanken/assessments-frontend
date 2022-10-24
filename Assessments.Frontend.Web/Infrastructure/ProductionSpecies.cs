using Azure.Storage.Blobs.Models;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class ProductionSpecies
    {
        public class ProductionSpeciesItem
        {
            public string Name { get;set;}

            public string ShortName { get; set; }
        }

        public static ProductionSpeciesItem[] AlienSpecies2023ProductionSpecies =
        {
            new ProductionSpeciesItem()
            {
                Name = "Tidligere eller nåværende bruksart",
                ShortName = "use"
            },
            new ProductionSpeciesItem()
            {
                Name = "Ikke bruksart",
                ShortName = "not"
            }
        };
    }
}
