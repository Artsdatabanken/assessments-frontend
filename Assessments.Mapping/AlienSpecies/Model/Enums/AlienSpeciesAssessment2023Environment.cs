using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023Environment
    {
        [Display(Name = "ukjent livsmiljø")]
        unknown,

        [Display(Name = "limnisk")]
        limnisk,

        [Display(Name = "marin")]
        marin,

        [Display(Name = "terrestrisk")]
        terrestrisk,

        [Display(Name = "limnisk og marin")]
        limMar,

        [Display(Name = "limnisk og terrestrisk")]
        limTer,

        [Display(Name = "marin og terrestrisk")]
        marTer,

        [Display(Name = "limnisk, marin og terrestrisk")]
        limMarTer
    }
}
