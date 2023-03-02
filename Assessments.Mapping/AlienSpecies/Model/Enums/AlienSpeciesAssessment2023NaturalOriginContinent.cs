using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023NaturalOriginContinent
    {
        [Display(Name = "Afrika")]
        Africa,

        [Display(Name = "Nord- og Mellom-Amerika")]
        AmericaNorth,

        [Display(Name = "Sør-Amerika")]
        AmericaSouth,

        [Display(Name = "Asia")]
        Asia,

        [Display(Name = "Europa")]
        Europe,

        [Display(Name = "Oseania")]
        Oceania
    }
}