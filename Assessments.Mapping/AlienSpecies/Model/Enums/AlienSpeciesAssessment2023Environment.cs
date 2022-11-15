using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023Environment
    {
        [Display(Name = "ukjent livsmiljø")]
        unknown,

        [Display(Name = "limnisk")]
        limnisk,

        [Display(Name = "marint")]
        marint,

        [Display(Name = "terrestrisk")]
        terrestrisk,

        [Display(Name = "limnisk og marint")]
        limMar,

        [Display(Name = "limnisk og terrestrisk")]
        limTer,

        [Display(Name = "marint og terrestrisk")]
        marTer,

        [Display(Name = "limnisk, marint og terrestrisk")]
        limMarTer
    }
}
