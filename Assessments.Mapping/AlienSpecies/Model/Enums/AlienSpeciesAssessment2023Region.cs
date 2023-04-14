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
        [Display(Name = "Svalbard med kystsone")] Sv,
        [Display(Name = "Jan Mayen")] Jm,
        [Display(Name = "Nordsjøen og Skagerrak")] Ns,
        [Display(Name = "Norskehavet")] Nh,
        [Display(Name = "Grønlandshavet")] Gh,
        [Display(Name = "Barentshavet nord og Polhavet")] Bn,
        [Display(Name = "Barentshavet sør")] Bs
    }
}