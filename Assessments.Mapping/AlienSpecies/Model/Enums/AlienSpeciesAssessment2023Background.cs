using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023Background
    {
        [Display(Name = "ikke valgt")]
        BackgroundNotSpecified,

        [Display(Name = "skriftlig dokumentasjon fra Norge")]
        WrittenDocumentationNorway,

        [Display(Name = "kun observasjoner fra Norge")]
        ObservationNorway,

        [Display(Name = "skriftlig dokumentasjon fra utlandet")]
        WrittenDocumentationAbroad,

        [Display(Name = "kun observasjoner fra utlandet")]
        ObservationAbroad,

        [Display(Name = "annet")]
        Other

    }
}