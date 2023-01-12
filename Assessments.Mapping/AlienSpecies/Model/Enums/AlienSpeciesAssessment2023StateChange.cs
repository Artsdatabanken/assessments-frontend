using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023StateChange
    {
        [Display(Name = "")]
        StateChangeNotSpecified,

        [Display(Name = "erosjonsutsatthet")]
        ER,

        [Display(Name = "oksygenmangel")]
        OM,

        [Display(Name = "sandstabilisering")]
        SS,

        [Display(Name = "vannmetning")]
        VM,

        [Display(Name = "enkeltartssammensetning")]
        AE,

        [Display(Name = "artsgruppesammensetning")]
        AG,

        [Display(Name = "relativ del-artsgruppesammensetning")]
        AR,

        [Display(Name = "eutrofiering")]
        EU,

        [Display(Name = "rask suksesjon")]
        RA,

        [Display(Name = "naturlig bestandsreduksjon på tresatt areal")]
        SN,

        [Display(Name = "ubalanse mellom trofiske nivåer")]
        UB,

        [Display(Name = "tresjiktstruktur")]
        TS,

        [Display(Name = "annen tilstandsendring")]
        other,

        [Display(Name = "naturtype endres til innsjø-vannmasser preget av introduksjon eller bortfall av strukturerende organismer (F11)")]
        F11,

        [Display(Name = "naturtype endres til elvevannmasser preget av introduksjon eller bortfall av strukturerende organismer (F13)")]
        F13
            
    }
}