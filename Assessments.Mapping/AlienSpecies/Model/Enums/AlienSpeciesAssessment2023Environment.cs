using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023Environment
    {
        [Display(Name = "ukjent livsmiljø")]
        Unknown,

        [Display(Name = "limnisk")]
        Limnisk,

        [Display(Name = "marint")]
        Marint,

        [Display(Name = "terrestrisk")]
        Terrestrisk,

        [Display(Name = "limnisk og marint")]
        LimMar,

        [Display(Name = "limnisk og terrestrisk")]
        LimTer,

        [Display(Name = "marint og terrestrisk")]
        MarTer,

        [Display(Name = "limnisk, marint og terrestrisk")]
        LimMarTer
    }
}
