using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023MajorTypeGroup
    {
        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.unknown), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        Unknown,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.freshwater_threatned), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        FreshWaterThreatned,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.mountains_threatned), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        MountainsThreatned,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.landform_threatned), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        LandformThreatned,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.marine_water_threatned), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        MarineWaterThreatned,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.marine_water_Svalbard_threatned), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        MarineWaterSvalbardThreatned,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.semi_natural_threatned), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        SemiNaturalThreatned,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.forest_threatned), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        ForestThreatned,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.Svalbard_threatned), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        SvalbardThreatned,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.wetlands_threatned), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        WetlandsThreatned,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.limnic_waterbody_systems), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        LimnicWaterbodySystems,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.marine_waterbody_systems), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        MarineWaterbodySystems,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.snow_ice_systems), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        SnowAndIceSystems,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.freshwater_bottom_systems), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        FreshwaterBottomSystems,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.marine_seabed_systems), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        MarineSeabedSystems,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.river_bottom_systems), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        RiverBottomSystems,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.terrestrial_systems), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        TerrestrialSystems,

        [Display(Name = nameof(AlienSpeciesAssessment2023MajorTypeGroupResource.wetland_systems), ResourceType = typeof(AlienSpeciesAssessment2023MajorTypeGroupResource))]
        WetlandSystems,

    }
}
