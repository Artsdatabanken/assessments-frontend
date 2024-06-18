using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023Region
    {
        [Display(Name = "Østfold")] Øs,
        [Display(Name = "Oslo og Akershus")] OsA,
        [Display(Name = "Hedmark")] He,
        [Display(Name = "Oppland")] Op,
        [Display(Name = "Buskerud")] Bu,
        [Display(Name = "Vestfold")] Ve,
        [Display(Name = "Telemark")] Te,
        [Display(Name = "Aust-Agder")] Aa,
        [Display(Name = "Vest-Agder")] Va,
        [Display(Name = "Rogaland")] Ro,
        [Display(Name = "Hordaland")] Ho,
        [Display(Name = "Sogn og Fjordane")] Sf,
        [Display(Name = "Møre og Romsdal")] Mr,
        [Display(Name = "Sør-Trøndelag")] St,
        [Display(Name = "Nord-Trøndelag")] Nt,
        [Display(Name = "Nordland")] No,
        [Display(Name = "Troms")] Tr,
        [Display(Name = "Finnmark")] Fi,
        [Display(Name = nameof(AlienSpeciesAssessment2023EvaluationContextResource.Svalbard), ResourceType = typeof(AlienSpeciesAssessment2023EvaluationContextResource))] Sv,
        [Display(Name = "Jan Mayen")] Jm,
        [Display(Name = nameof(AlienSpeciesAssessment2023RegionResource.north_sea), ResourceType = typeof(AlienSpeciesAssessment2023RegionResource))] Ns,
        [Display(Name = nameof(AlienSpeciesAssessment2023RegionResource.norwegian_ocean), ResourceType = typeof(AlienSpeciesAssessment2023RegionResource))] Nh,
        [Display(Name = nameof(AlienSpeciesAssessment2023RegionResource.greenland_sea), ResourceType = typeof(AlienSpeciesAssessment2023RegionResource))] Gh,
        [Display(Name = nameof(AlienSpeciesAssessment2023RegionResource.barents_north_polar), ResourceType = typeof(AlienSpeciesAssessment2023RegionResource))] Bn,
        [Display(Name = nameof(AlienSpeciesAssessment2023RegionResource.barents_south), ResourceType = typeof(AlienSpeciesAssessment2023RegionResource))] Bs
    }
}