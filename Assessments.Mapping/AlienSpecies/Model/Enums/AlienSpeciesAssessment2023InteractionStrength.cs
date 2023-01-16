using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023InteractionStrength
    {
        [Display(Name = "svak")]
        Weak,

        [Display(Name = "moderat")]
        Moderate,

        [Display(Name = "fortrengning")]
        Displacement,
    }
}