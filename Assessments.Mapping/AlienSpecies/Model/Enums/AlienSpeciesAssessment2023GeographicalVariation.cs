using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023GeographicalVariation
    {
        [Display(Name = "Artens evne til reproduksjon og/eller spredning er begrenset til visse bioklimatiske soner eller seksjoner")]
        ReproduksjonLimitedToCertainClimaticZones,

        [Display(Name = "Artens økologiske effekter er begrenset til visse bioklimatiske soner eller seksjoner")]
        EcologicalEffectLimitedToCertainClimaticZones,

        [Display(Name = "Artens økologiske effekter er begrenset til bestemte naturtyper")]
        EcologicalEffectLimitedToCertainNatureTypes,

        [Display(Name = "Artens økologiske effekt består utelukkende i interaksjoner med stedegne arter som har svært begrenset utbredelse")]
        EcologicalEffectLimitedToIndigenousSpecies,

        [Display(Name = "Artens evne til reproduksjon og/eller spredning er begrenset til visse kystvannssoner eller seksjoner")]
        ReproduksjonLimitedToCertainClimaticZonesMarine,

        [Display(Name = "Artens økologiske effekter er begrenset til visse kystvannssoner eller seksjoner")]
        EcologicalEffectLimitedToCertainClimaticZonesMarine,

        [Display(Name = "Artens økologiske effekter er begrenset til bestemte naturtyper")]
        EcologicalEffectLimitedToCertainNatureTypesMarine,

        [Display(Name = "Artens økologiske effekt består utelukkende i interaksjoner med stedegne arter som har svært begrenset utbredelse")]
        EcologicalEffectLimitedToIndigenousSpeciesMarine
    }
}
