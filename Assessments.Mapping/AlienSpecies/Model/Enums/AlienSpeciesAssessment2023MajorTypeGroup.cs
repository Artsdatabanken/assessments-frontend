using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023MajorTypeGroup
    {
        [Display(Name = "ukjent")]
        Unknown,

        [Display(Name = "Ferskvann")]
        FreshWaterThreatned,

        [Display(Name = "Fjell og berg")]
        MountainsThreatned,

        [Display(Name = "Landform")]
        LandformThreatned,

        [Display(Name = "Marint dypvann")]
        MarineDeepWaterThreatned,

        [Display(Name = "Marint gruntvann")]
        MarineWaterThreatned,

        [Display(Name = "Marint gruntvann, Svalbard")]
        MarineWaterSvalbardThreatned,

        [Display(Name = "Semi-naturlig")]
        SemiNaturalThreatned,

        [Display(Name = "Skog")]
        ForestThreatned,

        [Display(Name = "Svalbard")]
        SvalbardThreatned,

        [Display(Name = "Våtmark")]
        WetlandsThreatned,

        [Display(Name = "Limniske vannmasser")]
        LimnicWaterbodySystems,

        [Display(Name = "Marine vannmasser")]
        MarineWaterbodySystems,

        [Display(Name = "Snø- og issystemer")]
        SnowAndIceSystems,

        [Display(Name = "Innsjøbunnsystemer")]
        FreshwaterBottomSystems,

        [Display(Name = "Saltvannsbunnsystemer")]
        MarineSeabedSystems,

        [Display(Name = "Elvebunnsystemer")]
        RiverBottomSystems,

        [Display(Name = "Fastmarkssystemer")]
        TerrestrialSystems,

        [Display(Name = "Våtmarkssystemer")]
        WetlandSystems,

    }
}
