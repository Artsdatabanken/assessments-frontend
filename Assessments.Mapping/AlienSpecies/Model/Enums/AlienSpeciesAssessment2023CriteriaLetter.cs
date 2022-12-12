using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023CriteriaLetter
    {
        [Display(Name = "Median levetid i Norge (A-kriteriet)")]
        A,

        [Display(Name = "Ekspansjonshastighet (B-kriteriet)")]
        B,

        [Display(Name = "Kolonisert naturtypeareal (C-kriteriet)")]
        C,

        [Display(Name = "Effekter på truede arter eller nøkkelarter (D-kriteriet)")]
        D,

        [Display(Name = "Effekter på øvrige rødlistevurderte arter (E-kriteriet)")]
        E,

        [Display(Name = "Effekter på truede eller sjeldne naturtyper (F-kriteriet)")]
        F,

        [Display(Name = "Effekter på øvrige naturtyper (G-kriteriet)")]
        G,

        [Display(Name = "Overføring av genetisk materiale (H-kriteriet)")]
        H,

        [Display(Name = "Overføring av parasitter eller patogener (I-kriteriet)")]
        I
    }
}