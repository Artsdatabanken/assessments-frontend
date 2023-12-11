using Assessments.Frontend.Web.Infrastructure.RedlistSpecies.Enums;
using Assessments.Shared.Helpers;
using System;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.RedlistSpecies
{
    public class Areas
    {
        public static readonly Filter.FilterItem[] RedlistSpecies2021AreasFilters = Enum.GetValues<RedlistSpeciesAssessment2021EvaluationContext>()
            .Select(x => new Filter.FilterItem
            {
                Name = x.DisplayName(),
                NameShort = x.ToString()
            }).ToArray();

        public static readonly Filter.FilterAndMetaData RedlistSpecies2021Areas = new()
        {
            Filters = RedlistSpecies2021AreasFilters,
            FilterDescription = "",
            FilterButtonName = "områdefiltre",
            FilterButtonText = "Vurderingsområde"
        };
    }

    public class Categories
    {
        public static readonly Filter.FilterItem[] RedlistSpecies2021CategoriesFilters = Enum.GetValues<RedlistSpeciesAssessment2021Category>()
            .Select(x => new Filter.FilterItem
            {
                NameShort = x.ToString(),
                Name = x.DisplayName(),
                Description = x.DisplayName()
            }).ToArray();

        public static readonly Filter.FilterAndMetaData RedlistSpecies2021Categories = new()
        {
            Filters = RedlistSpecies2021CategoriesFilters,
            FilterDescription = "",
            FilterButtonName = "kategorifiltre",
            FilterButtonText = "Kategori"
        };
    }

    public class Criteria
    {
        public static readonly Filter.FilterItem[] RedlistSpecies2021CriteriaFilters = Enum.GetValues<RedlistSpeciesAssessment2021Criteria>()
            .Select(x => new Filter.FilterItem
            {
                NameShort = x.ToString(),
                Name = x.DisplayName(),
                Description = x.DisplayName()
            }).ToArray();

        public static readonly Filter.FilterAndMetaData RedlistSpecies2021Criteria = new()
        {
            Filters = RedlistSpecies2021CriteriaFilters,
            FilterDescription = "",
            FilterButtonName = "kriteriefiltre",
            FilterButtonText = "Kriterier"
        };
    }
}
