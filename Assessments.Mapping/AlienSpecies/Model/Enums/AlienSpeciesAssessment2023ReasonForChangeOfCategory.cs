using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ReasonForChangeOfCategory
    {
        [Display(Name = "Ny kunnskap")]
        NewKnowledge,

        [Display(Name = "Ny tolkning av tidligere data")]
        NewInterpretation,

        [Display(Name = "Endrede avgrensninger eller retningslinjer")]
        ChangedGuidelines,

        [Display(Name = "Endret tolkning av retningslinjer")]
        ChangedGuidelinesInterpretation,

        [Display(Name = "Endret status (taksonomi, til/fra stedegen)")]
        ChangedStatus
    }
}