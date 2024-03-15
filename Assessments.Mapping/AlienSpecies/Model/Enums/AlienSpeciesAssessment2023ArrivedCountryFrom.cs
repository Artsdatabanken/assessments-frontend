using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ArrivedCountryFrom
    {
        [Display(Name = nameof(AlienSpeciesAssessment2023ArrivedCountryFromResource.other_region), ResourceType = typeof(AlienSpeciesAssessment2023ArrivedCountryFromResource))]
        OtherRegion,

        [Display(Name = nameof(AlienSpeciesAssessment2023ArrivedCountryFromResource.origin), ResourceType = typeof(AlienSpeciesAssessment2023ArrivedCountryFromResource))]
        Origin,

        [Display(Name = nameof(AlienSpeciesAssessment2023ArrivedCountryFromResource.other), ResourceType = typeof(AlienSpeciesAssessment2023ArrivedCountryFromResource))]
        Other,

        [Display(Name = nameof(AlienSpeciesAssessment2023ArrivedCountryFromResource.unknown), ResourceType = typeof(AlienSpeciesAssessment2023ArrivedCountryFromResource))]
        Unknown,
    }
}