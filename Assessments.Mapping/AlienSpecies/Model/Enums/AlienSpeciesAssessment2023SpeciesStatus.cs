using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Assessments.Shared.Helpers;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023SpeciesStatus
    {
        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.not_indicated), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        [Description("")]
        NotIndicated,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.not_in_Norway), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource))] 
        [LocalizedDescription(nameof(AlienSpeciesAssessment2023SpeciesStatusResource.not_in_Norway_description), typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        Abroad,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.indoors), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        [LocalizedDescription(nameof(AlienSpeciesAssessment2023SpeciesStatusResource.indoors_description), typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        B1,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.outdoors_production_area), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        [LocalizedDescription(nameof(AlienSpeciesAssessment2023SpeciesStatusResource.outdoors_production_area_description), typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        B2,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.documented_Norwegian_nature),
            ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        [LocalizedDescription(nameof(AlienSpeciesAssessment2023SpeciesStatusResource.documented_Norwegian_nature_description), typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        C0,
        
        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.survive_winter_outdoors), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        [LocalizedDescription(nameof(AlienSpeciesAssessment2023SpeciesStatusResource.survive_winter_outdoors_description), typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        C1,

        [Display(Name = nameof(AlienSpeciesAssessment2023AlienSpeciesCategoryResource.alien_species), ResourceType = typeof(AlienSpeciesAssessment2023AlienSpeciesCategoryResource))]
        [LocalizedDescription(nameof(AlienSpeciesAssessment2023SpeciesStatusResource.reproduces_unaidedly_description), typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        C2,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.established), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        [LocalizedDescription(nameof(AlienSpeciesAssessment2023SpeciesStatusResource.established_description), typeof(AlienSpeciesAssessment2023SpeciesStatusResource))]
        C3
    }
}
