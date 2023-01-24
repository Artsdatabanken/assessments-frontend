using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum RedlistCategory
    {
        [Display(Name = "Ukjent kategori")]
        Unknown,

        [Display(Name = "Regionalt utdødd")]
        RE,

        [Display(Name = "Kritisk truet")]
        CR,

        [Display(Name = "Sterkt truet")]
        EN,

        [Display(Name = "Sårbar")]
        VU,

        [Display(Name = "Nær truet")]
        NT,

        [Display(Name = "Datamangel")]
        DD,

        [Display(Name = "Livskraftig")]
        LC,

        [Display(Name = "Ikke egnet")]
        NA,

        [Display(Name = "Ikke vurdert")]
        NE
    }
}
