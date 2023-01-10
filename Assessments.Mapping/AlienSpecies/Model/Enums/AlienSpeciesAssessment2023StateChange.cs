using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023StateChange
    {
        [Display(Name = "")]
        StateChangeNotSpecified,

        [Display(Name = "Erosjonsutsatthet")]
        ER,

        [Display(Name = "Oksygenmangel")]
        OM,

        [Display(Name = "Sandstabilisering")]
        SS,

        [Display(Name = "Vannmetning")]
        VM,

        [Display(Name = "Enkeltartssammensetning")]
        AE,

        [Display(Name = "Artsgruppesammensetning")]
        AG,

        [Display(Name = "Relativ del-artsgruppesammensetning")]
        AR,

        [Display(Name = "Eutrofiering")]
        EU,

        [Display(Name = "Rask suksesjon")]
        RA,

        [Display(Name = "Naturlig bestandsreduksjon på tresatt areal")]
        SN,

        [Display(Name = "Ubalanse mellom trofiske nivåer")]
        UB,

        [Display(Name = "Tresjiktstruktur")]
        TS,

        [Display(Name = "Annen tilstandsendring")]
        other,

        [Display(Name = "Naturtype endres til innsjø-vannmasser preget av introduksjon eller bortfall av strukturerende organismer (F11)")]
        F11,

        [Display(Name = "Naturtype endres til elvevannmasser preget av introduksjon eller bortfall av strukturerende organismer (F13)")]
        F13
            
    }
}