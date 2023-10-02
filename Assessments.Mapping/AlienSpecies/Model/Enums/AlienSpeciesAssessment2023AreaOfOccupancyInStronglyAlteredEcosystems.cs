using System.ComponentModel.DataAnnotations;
using Assessments.Shared.Resources.Enums.AlienSpecies;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystems
    {
        [Display(Name = nameof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource.less_than_five), ResourceType = typeof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource))]
        Value0,

        [Display(Name = nameof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource.from_five_to_twentyfive), ResourceType = typeof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource))]
        Value5,

        [Display(Name = nameof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource.from_twentyfive_to_seventyfive), ResourceType = typeof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource))]
        Value25,

        [Display(Name = nameof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource.From_seventyfive_to_ninetyfive), ResourceType = typeof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource))]
        Value75,

        [Display(Name = nameof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource.over_ninetyfive), ResourceType = typeof(AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystemsResource))]
        Value95
    }
}