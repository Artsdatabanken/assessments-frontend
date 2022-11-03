using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023Category
    {
        // ReSharper disable InconsistentNaming
        [Display(Name = "Svært høy risiko")]
        SE,

        [Display(Name = "Høy risiko")]
        HI,

        [Display(Name = "Potensielt høy risiko")]
        PH,

        [Display(Name = "Lav risiko")]
        LO,

        [Display(Name = "Ingen kjent risiko")]
        NK,

        [Display(Name = "Ikke risikovurdert")]
        NR
    }
}