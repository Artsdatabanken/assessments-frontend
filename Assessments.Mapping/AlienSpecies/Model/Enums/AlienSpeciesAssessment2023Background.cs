using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023Background
    {
        [Display(Name = "")]
        BackgroundNotSpecified,

        [Display(Name = "Skriftlig dokumentasjon fra Norge")]
        WrittenDocumentationNorway,

        [Display(Name = "Kun observasjoner fra Norge")]
        ObservationNorway,

        [Display(Name = "Skriftlig dokumentasjon fra utlandet")]
        WrittenDocumentationAbroad,

        [Display(Name = "Kun observasjoner fra utlandet")]
        ObservationAbroad,

        [Display(Name = "Annet")]
        Other

    }
}