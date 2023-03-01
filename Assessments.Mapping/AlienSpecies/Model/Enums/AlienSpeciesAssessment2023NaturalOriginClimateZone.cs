using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023NaturalOriginClimateZone
    {
        [Display(Name = "Polart")]
        Polar,

        [Display(Name = "Temperert boreal")]
        Temperateboreal,

        [Display(Name = "Temperert nemoral")]
        Temperatenemoral,

        [Display(Name = "Temperert tørt")]
        Temperatedry,

        [Display(Name = "Subtropisk uspesifisert")]
        Subtropicunspecified,

        [Display(Name = "Subtropisk Middelhavsklima")]
        Subtropicmediterranean,

        [Display(Name = "Subtropisk fuktig")]
        Subtropichumid,

        [Display(Name = "Subtropisk tørt")]
        Subtropicdry,

        [Display(Name = "Subtropisk Kappregionen")]
        Subtropiccaperegion,

        [Display(Name = "Subtropisk/Tropisk høydeklima")]
        Subtropichighlands,

        [Display(Name = "Tropisk")]
        Tropic,

        [Display(Name = "Ukjent klimasone")]
        Unknown
    }
}