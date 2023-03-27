using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023MajorTypeGroup
    {
        [Display(Name = "ukjent")]
        [Description("Na0")]
        Unknown,

        [Display(Name = "Ferskvann")]
        [Description("Na1")]
        FreshWater,

        [Display(Name = "Fjell og berg")]
        [Description("Na2")]
        Mountain,

        [Display(Name = "Landform")]
        [Description("Na3")]
        LandForm,

        [Display(Name = "Marint dypvann")]
        [Description("Na4")]
        MarineDeepWater,

        [Display(Name = "Marint gruntvann")]
        [Description("Na5")]
        MarineShallowWater,

        [Display(Name = "Marint gruntvann, Svalbard")]
        [Description("Na6")]
        MarineShallowWaterSvalbard,

        [Display(Name = "Semi-naturlig")]
        [Description("Na7")]
        SemiNatural,

        [Display(Name = "Skog")]
        [Description("Na8")]
        Forest,

        [Display(Name = "Svalbard")]
        [Description("Na9")]
        Svalbard,

        [Display(Name = "Våtmark")]
        [Description("Na10")]
        Wetlands,
    }
}
