using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.RedlistSpecies
{
    public class Areas
    {
        public static readonly Filter.FilterItem[] RedlistSpecies2021AreasFilters = new Filter.FilterItem[]
        {
            new ()
            {
                Name = "Norge",
                NameShort = "N"
            },
            new() {
                Name = "Svalbard",
                NameShort = "S"
            }
        };

        public static readonly Filter.FilterAndMetaData RedlistSpecies2021Areas = new()
        {
            Filters = RedlistSpecies2021AreasFilters,
            FilterDescription = "",
            FilterButtonName = "områdefiltre",
            FilterButtonText = "Område"
        };
    }
}
