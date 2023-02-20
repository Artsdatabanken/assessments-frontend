using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023NaturalOriginMarine
    {
        [Display(Name = "Nordishavet")]
        Nordis,

        [Display(Name = "Atlanterhavet nordvest")]
        AtlantNordVest,

        [Display(Name = "Atlanterhavet nordøst")]
        AtlantNordOst,

        [Display(Name = "Atlanterhavet tropisk")]
        AtlantTropic,

        [Display(Name = "Atlanterhavet sørlig")]
        AtlantSor,

        [Display(Name = "Østersjøen")]
        Osters,

        [Display(Name = "Middelhavet")]
        Middel,

        [Display(Name = "Svartehavet")]
        BlackSea,

        [Display(Name = "Det kaspiske hav")]
        CaspianSea,

        [Display(Name = "Stillehavet nordlig")]
        StilleNord,

        [Display(Name = "Stillehavet tropisk")]
        StilleTropic,

        [Display(Name = "Stillehavet sørlig")]
        StilleSor,

        [Display(Name = "Indiahavet tropisk")]
        IndianOTropic,

        [Display(Name = "Indiahavet sørlig")]
        IndianOSouth,

        [Display(Name = "Sørishavet")]
        Sorish,

        [Display(Name = "Ukjent")]
        Ukjent
    }
}