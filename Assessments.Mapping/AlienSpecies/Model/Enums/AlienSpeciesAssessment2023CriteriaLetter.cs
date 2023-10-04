using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023CriteriaLetter
    {
        [Display(Name = nameof(AlienSpeciesAssessment2023CriteriaLetterResource.A_median_lifetime), ResourceType = typeof(AlienSpeciesAssessment2023CriteriaLetterResource))]
        A,

        [Display(Name = nameof(AlienSpeciesAssessment2023CriteriaLetterResource.B_expansion_speed), ResourceType = typeof(AlienSpeciesAssessment2023CriteriaLetterResource))]
        B,

        [Display(Name = nameof(AlienSpeciesAssessment2023CriteriaLetterResource.C_colonized_area), ResourceType = typeof(AlienSpeciesAssessment2023CriteriaLetterResource))]
        C,

        [Display(Name = nameof(AlienSpeciesAssessment2023CriteriaLetterResource.D_effects_threatened_species), ResourceType = typeof(AlienSpeciesAssessment2023CriteriaLetterResource))]
        D,

        [Display(Name = nameof(AlienSpeciesAssessment2023CriteriaLetterResource.E_effects_other_species), ResourceType = typeof(AlienSpeciesAssessment2023CriteriaLetterResource))]
        E,

        [Display(Name = nameof(AlienSpeciesAssessment2023CriteriaLetterResource.F_effects_threatened_ecosystems), ResourceType = typeof(AlienSpeciesAssessment2023CriteriaLetterResource))]
        F,

        [Display(Name = nameof(AlienSpeciesAssessment2023CriteriaLetterResource.G_effects_other_ecosystems), ResourceType = typeof(AlienSpeciesAssessment2023CriteriaLetterResource))]
        G,

        [Display(Name = nameof(AlienSpeciesAssessment2023CriteriaLetterResource.H_transfer_genetic_material), ResourceType = typeof(AlienSpeciesAssessment2023CriteriaLetterResource))]
        H,

        [Display(Name = nameof(AlienSpeciesAssessment2023CriteriaLetterResource.I_transfer_parasites), ResourceType = typeof(AlienSpeciesAssessment2023CriteriaLetterResource))]
        I
    }
}