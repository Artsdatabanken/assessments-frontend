using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023SpeciesStatus
    {
        [Display(ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource), Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.not_indicated))]
        [Description("")]
        NotIndicated,

        [Display(ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource), Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.not_in_Norway), Description = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.not_in_Norway_description))] 
        Abroad,

        [Display(ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource), Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.indoors), Description = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.indoors_description))]
        B1,

        [Display(ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource), Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.outdoors_production_area), Description = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.outdoors_production_area_description))]
        B2,

        [Display(ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource), Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.documented_Norwegian_nature), Description = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.documented_Norwegian_nature_description))]
        C0,
        
        [Display(ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource), Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.survive_winter_outdoors), Description = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.survive_winter_outdoors_description))]
        C1,

        [Display(ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource), Name = nameof(AlienSpeciesAssessment2023AlienSpeciesCategoryResource.alien_species), Description = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.reproduces_unaidedly_description))]
        C2,

        [Display(ResourceType = typeof(AlienSpeciesAssessment2023SpeciesStatusResource), Name = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.established), Description = nameof(AlienSpeciesAssessment2023SpeciesStatusResource.established_description))]
        C3
    }
}
