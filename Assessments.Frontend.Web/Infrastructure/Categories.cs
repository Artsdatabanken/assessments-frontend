using System.Collections.Generic;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class Categories
    {
        public class CategoryItem
        {
            public string Category { get; set; }

            public string TagLine { get; set; }

            public string Description { get; set; }

            public string PresentationString { get; set; }
        }

        public static CategoryItem[] AlienSpecies2023Categories =
        {
            new CategoryItem()
            {
                Category = "SE",
                TagLine = "Svært høy risiko",
                Description = "- svært høy risiko.",
                PresentationString = "svært høy risiko"
            },
            new CategoryItem()
            {
                Category = "HI",
                TagLine = "Høy risiko",
                Description = "- høy risiko.",
                PresentationString = "høy risiko"
            },
            new CategoryItem()
            {
                Category = "PH",
                TagLine = "Potensielt høy risiko",
                Description = "- potensielt høy risiko.",
                PresentationString = "potensielt høy risiko"
            },
            new CategoryItem()
            {
                Category = "LO",
                TagLine = "Lav risiko",
                Description = "- lav risiko.",
                PresentationString = "lav risiko"
            },
            new CategoryItem()
            {
                Category = "NK",
                TagLine = "Ingen kjent risiko",
                Description = "- ingen kjent risiko.",
                PresentationString = "ingen kjent risiko"
            },
            new CategoryItem()
            {
                Category = "NR",
                TagLine = "Ikke vurdert",
                Description = "- ikke vurdert.",
                PresentationString = "ikke vurdert"
            }
        };
    }
}


//"CR": {
//    "tagline": "Kritisk truet",
//    "description": "– ekstremt høy risiko for utdøing.",
//    "presentationstring": "kritisk truet "
//  },