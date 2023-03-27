using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023SpeciesStatus
    {
        [Display(Name = "Ikke i Norge")]
        [Description("ikke forekommer i Norge")]
        A,

        [Display(Name = "Innendørs")]
        [Description("forekommer innendørs eller i lukkede installasjoner")]
        B1,

        [Display(Name = "Utendørs i eget produksjonsareal")]
        [Description("forekommer utendørs i eget produksjonsareal")]
        B2,

        [Display(Name = "Observert i norsk natur")]
        [Description("er dokumentert fra norsk natur")]
        C0,

        [Display(Name = "Overlever vinteren utendørs")]
        [Description("kan overleve vinteren utendørs og uten hjelp")]
        C1,

        [Display(Name = "Selvstendig reproduserende")]
        [Description("er selvstendig reproduserende")]
        C2,

        [Display(Name = "Etablert")]
        [Description("er etablert")]
        C3
    }
}
