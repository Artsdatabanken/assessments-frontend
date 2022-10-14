using System.Collections.Generic;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class Areas
    {
        public class AreaItem
        {
            public string Area { get; set; }

            public string AreaShort { get; set; }
        }

        public static readonly AreaItem[] AlienSpecies2023Areas =
        {
            new AreaItem()
            {
                Area = "Norge",
                AreaShort = "N"
            },
            new AreaItem()
            {
                Area = "Svalbard",
                AreaShort = "S"
            }
        };
    }
}
