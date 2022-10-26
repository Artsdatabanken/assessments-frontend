using System.Collections.Generic;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class Categories
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023Categories =
        {
            new Filter.FilterItem()
            {
                NameShort = "SE",
                Name = "Svært høy risiko",
                Description = "svært høy risiko"
            },
            new Filter.FilterItem()
            {
                NameShort = "HI",
                Name = "Høy risiko",
                Description = "høy risiko"
            },
            new Filter.FilterItem()
            {
                NameShort = "PH",
                Name = "Potensielt høy risiko",
                Description = "potensielt høy risiko"
            },
            new Filter.FilterItem()
            {
                NameShort = "LO",
                Name = "Lav risiko",
                Description = "lav risiko"
            },
            new Filter.FilterItem()
            {
                NameShort = "NK",
                Name = "Ingen kjent risiko",
                Description = "ingen kjent risiko"
            },
            new Filter.FilterItem()
            {
                NameShort = "NR",
                Name = "Ikke vurdert",
                Description = "ikke vurdert"
            }
        };
    }
}


//"CR": {
//    "tagline": "Kritisk truet",
//    "description": "– ekstremt høy risiko for utdøing.",
//    "presentationstring": "kritisk truet "
//  },