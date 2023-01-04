using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023SpeciesStatus
    {
        [Display(Name = "Ikke relevant")]
        [Description("er ikke relevant")]
        empty,

        [Display(Name = "Ikke i Norge")]
        [Description("ikke forekommer i Norge")]
        a,

        [Display(Name = "Innendørs")]
        [Description("forekommer innendørs eller i lukkede installasjoner")]
        b1,

        [Display(Name = "Utendørs i eget produksjonsareal")]
        [Description("forekommer utendørs i eget produksjonsareal")]
        b2,

        [Display(Name = "Observert i norsk natur")]
        [Description("er dokumentert fra norsk natur")]
        c0,

        [Display(Name = "Overlever vinteren utendørs")]
        [Description("kan overleve vinteren utendørs og uten hjelp")]
        c1,

        [Display(Name = "Selvstendig reproduserende")]
        [Description("er selvstendig reproduserende")]
        c2,

        [Display(Name = "Etablert")]
        [Description("er etablert")]
        c3
    }
}
