using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public class AlienSpeciesAssessment2023IntroductionPathway
    {
        public enum IntroductionSpread
        {
            [Display(Name = "")]
            NotChosen,

            [Display(Name = "Introduksjon")]
            Introduction,

            [Display(Name = "Spredning")]
            Spread
        }

        public enum InfluenceFactor
        {
            [Display(Name = "")]
            NotChosen,

            [Display(Name = "Ukjent")]
            Unknown,

            [Display(Name = "Tallrike ganger pr. år")]
            NumerousYearly,

            [Display(Name = "Ca. årlig")]
            Yearly,

            [Display(Name = "Flere ganger pr. 10. år")]
            SeveralPr10years,

            [Display(Name = "Sjeldnere enn hvert 10. år")]
            RarerThan10years
        }

        public enum Magnitude
        {
            [Display(Name = "")]
            NotChosen,

            [Display(Name = "Ukjent")]
            Unknown,

            [Display(Name = "1")]
            Smallest,

            [Display(Name = "2 - 10")]
            Small,

            [Display(Name = "11 - 100")]
            Medium,

            [Display(Name = "101 - 1000")]
            Large,

            [Display(Name = "> 1000")]
            MoreThan1000
        }

        public enum TimeOfIncident
        {
            [Display(Name = "")]
            NotChosen,

            [Display(Name = "Kun historisk")]
            Historic,

            [Display(Name = "Opphørt, men kan inntreffe igjen")]
            Ceased,

            [Display(Name = "Pågående")]
            Ongoing,

            [Display(Name = "Kun i fremtiden")]
            Future,

            [Display(Name = "Ukjent")]
            Unknown
        }

        public enum MainCategory
        {
            [Display(Name = "")]
            Unknown,

            [Display(Name = "Rømning/forvilling")]
            Escaped,

            [Display(Name = "Blindpassasjer med transport")]
            Stowaway,

            [Display(Name = "Korridor")]
            Corridor,

            [Display(Name = "Tilsiktet utsetting")]
            Released,

            [Display(Name = "Egenspredning")]
            NaturalDispersal,

            [Display(Name = "Forurensning av vare")]
            Transportpolution,

            [Display(Name = "Direkte import")]
            ImportDirect
        }
    }
}
