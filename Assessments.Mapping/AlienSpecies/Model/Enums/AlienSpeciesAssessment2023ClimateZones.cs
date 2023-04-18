using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ClimateZones
    {
        [Display(Name = "Nordsjøen og Skagerrak")]
        NorthSeaAndSkagerrak,

        [Display(Name = "Norskehavet")]
        NorwegianSea,

        [Display(Name = "Barentshavet sør")]
        BarentsSea,

        [Display(Name = "Grønlandshavet")]
        GreenlandSea,

        [Display(Name = "Barentshavet nord og Polhavet")]
        PolarSea,

        [Display(Name = "Mellomarktisk tundrasone")]
        MidArctic,

        [Display(Name = "Nordarktisk tundrasone")]
        NorthArctic,

        [Display(Name = "Nordarktisk polarørkensone")]
        NorthArcticDesert,

        [Display(Name = "Boreonemoral sone")]
        Boreonemoral,

        [Display(Name = "Sørboreal sone")]
        SouthBoreal,

        [Display(Name = "Mellomboreal sone")]
        MidBoreal,

        [Display(Name = "Nordboreal sone")]
        NorthBoreal,

        // Something strange here, but somehow some data for north boreal has a double string...
        [Display(Name = "Nordboreal sone")]
        NorthBorealnorthBoreal,

        [Display(Name = "Alpine soner")]
        AlpineZones,
    }
}
