using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023Environment
    {
        [Display(Name = nameof(AlienSpeciesAssessment2023EnvironmentResource.unknown), ResourceType = typeof(AlienSpeciesAssessment2023EnvironmentResource))]
        Unknown,

        [Display(Name = nameof(AlienSpeciesAssessment2023EnvironmentResource.limnic), ResourceType = typeof(AlienSpeciesAssessment2023EnvironmentResource))]
        Limnisk,

        [Display(Name = nameof(AlienSpeciesAssessment2023EnvironmentResource.marine), ResourceType = typeof(AlienSpeciesAssessment2023EnvironmentResource))]
        Marint,

        [Display(Name = nameof(AlienSpeciesAssessment2023EnvironmentResource.terrestric), ResourceType = typeof(AlienSpeciesAssessment2023EnvironmentResource))]
        Terrestrisk,

        [Display(Name = nameof(AlienSpeciesAssessment2023EnvironmentResource.limnic_marine), ResourceType = typeof(AlienSpeciesAssessment2023EnvironmentResource))]
        LimMar,

        [Display(Name = nameof(AlienSpeciesAssessment2023EnvironmentResource.limnic_terrestrial), ResourceType = typeof(AlienSpeciesAssessment2023EnvironmentResource))]
        LimTer,

        [Display(Name = nameof(AlienSpeciesAssessment2023EnvironmentResource.marine_terrestrial), ResourceType = typeof(AlienSpeciesAssessment2023EnvironmentResource))]
        MarTer,

        [Display(Name = nameof(AlienSpeciesAssessment2023EnvironmentResource.all_lifestyles), ResourceType = typeof(AlienSpeciesAssessment2023EnvironmentResource))]
        LimMarTer
    }
}
