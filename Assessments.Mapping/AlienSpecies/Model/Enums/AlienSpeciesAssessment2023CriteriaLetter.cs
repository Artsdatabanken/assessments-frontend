using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023CriteriaLetter
    {
        [Display(Name = "Median levetid i Norge")]
        A,

        [Display(Name = "Ekspansjonshastighet")]
        B,

        [Display(Name = "Kolonisert naturtypeareal")]
        C,

        [Display(Name = "Effekter på truede arter eller nøkkelarter")]
        D,

        [Display(Name = "Effekter på øvrige stedegne arter")]
        E,

        [Display(Name = "Effekter på truede eller sjeldne naturtyper")]
        F,

        [Display(Name = "Effekter på øvrige naturtyper")]
        G,

        [Display(Name = "Overføring av genetisk materiale")]
        H,

        [Display(Name = "Overføring av parasitter eller patogener")]
        I
    }
}