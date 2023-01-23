using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023InteractionType
    {
        [Display(Name = "allelopati")]
        Allelopathy,

        [Display(Name = "konkurranse om mat")]
        CompetitionFood,

        [Display(Name = "konkurranse om plass")]
        CompetitionSpace,

        [Display(Name = "predasjon")]
        Predation,

        [Display(Name = "parasittering")]
        Parasitizing,

        [Display(Name = "fytofagi")]
        Phytophagy,

        [Display(Name = "andre")]
        Other
    }
}