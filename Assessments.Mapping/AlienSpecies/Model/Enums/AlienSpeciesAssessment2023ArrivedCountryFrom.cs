using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ArrivedCountryFrom
    {
        [Display(Name = "Fastlands-Norge")]
        OtherRegion,

        [Display(Name = "Opprinnelsessted (utlandet)")]
        Origin,

        [Display(Name = "Annet sted (utlandet)")]
        Other,

        [Display(Name = "Ukjent")]
        Unknown,
    }
}