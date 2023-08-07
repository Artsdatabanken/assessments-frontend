
using System.ComponentModel;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023Export
    {
        [DisplayName("Id for vurderingen")]
        [Description("Id for 2023 vurderingen")]
        public int Id { get; set; }

        [DisplayName("Vurderingsområde")]
        [Description("Er arten vurdert for Norge eller Svalbard")]
        public string AssessmentArea { get; set; }

        [DisplayName("Ekspertkomité")]
        [Description("Ekspertgruppen bak 2023-vurderingen")]
        public string ExpertGroup { get; set; }

        [DisplayName("Artsgruppe")]
        [Description("Artsgruppen arten tilhører")]
        public string SpeciesGroup { get; set; }

        [DisplayName("Taksonomisk sti")]
        [Description("Taksonomisk sti for arten")]
        public string TaxonHierarcy { get; set; }

        [DisplayName("Vitenskapelig navn id")]
        [Description("Gyldig vitenskapelig navn id ved vurderingstidspunkt, i henhold til Artsnavnebase")]
        public int ScientificNameId { get; set; }

        [DisplayName("Vitenskapelig navn")]
        [Description("Gyldig vitenskapelig navn i henhold til Artsnavnebase")]
        public string ScientificName { get; set; }

        [DisplayName("Autor")]
        [Description("Autor for gyldig vitenskapelig navn i henhold til Artsnavnebase")]
        public string ScientificNameAuthor { get; set; }

        [DisplayName("Populærnavn")]
        [Description("Prioritert norsk populærnavn i henhold til Artsnavnebase")]
        public string VernacularName { get; set; }

        [DisplayName("Fremmedartsstatus")]
        [Description("Om arten er selvstendig reproduserende, en dørstokkart, regionalt fremmed osv.")]
        public string AlienSpeciesCategory { get; set; }

        [DisplayName("Etableringsklasse")]
        [Description("Angir etableringsklassen arten har i Norge i dag. Går fra laveste kategori (A) Arten forekommer ikke Norge til høyeste kategori (E) Arten har etter introduksjonen selv spredd seg til og etablert [2.2.] seg i minst ti ytterligere forekomster i norsk natur")]
        public string EstablishmentCategory { get; set; }

        [DisplayName("Risikokategori 2023")]
        [Description("Endelig kategori i 2023 etter GEIAAS kategorier and kriterier")]
        public string Category { get; set; }

        [DisplayName("Utslagsgivende kriterier 2023")]
        [Description("Utslagsgivende kriterier i 2023 etter GEIAAS metoden")]
        public string DecisiveCriteria { get; set; }

        [DisplayName("Risikokategori 2018")]
        [Description("Endelig kategori i 2018 etter GEIAAS kategorier and kriterier")]
        public string PreviousAssessmentCategory2018 { get; set; }

        [DisplayName("Skår Invasjonspotensial")]
        [Description("Artens delkategori (1-4) på invasjonsaksen i risikomatrisen. Denne bestemmes av artens invasjonspotensial")]
        public int? ScoreInvasionPotential { get; set; }

        [DisplayName("Skår Økologisk effekt")]
        [Description("Artens delkategori (1-4) på effektaksen i risikomatrisen. Denne bestemmes av artens økologiske effekt")]
        public int? ScoreEcologicalEffect { get; set; }

        [DisplayName("Skår A-kriteriet")]
        [Description("Artens delkategori (1-4) på A-kriteriet, artens mediane levetid i Norge")]
        public int? CriterionAScore { get; set; }

        [DisplayName("Skår B-kriteriet")]
        [Description("Artens delkategori (1-4) på B-kriteriet, artens ekspansjonshastighet i norsk natur")]
        public int? CriterionBScore { get; set; }

        [DisplayName("Skår C-kriteriet")]
        [Description("Artens delkategori (1-4) på C-kriteriet, kolonisert naturtypeareal")]
        public int? CriterionCScore { get; set; }

        [DisplayName("Skår D-kriteriet")]
        [Description("Artens delkategori (1-4) på D-kriteriet, artens negative effekter på trua arter og nøkkelarter")]
        public int? CriterionDScore { get; set; }


        [DisplayName("Skår E-kriteriet")]
        [Description("Artens delkategori (1-4) på E-kriteriet, artens negative effekter på stedegne arter (ikke trua eller nøkkelarter)")]
        public int? CriterionEScore { get; set; }


        [DisplayName("Skår F-kriteriet")]
        [Description("Artens delkategori (1-4) på F-kriteriet, artens negative effekter på trua eller sjeldne naturtyper")]
        public int? CriterionFScore { get; set; }


        [DisplayName("Skår G-kriteriet")]
        [Description("Artens delkategori (1-4) på G-kriteriet, artens negative effekter på naturtyper (ikke trua eller sjelden)")]
        public int? CriterionGScore { get; set; }


        [DisplayName("Skår H-kriteriet")]
        [Description("Artens delkategori (1-4) på H-kriteriet, overføring av genetisk materiale til stedegen art")]
        public int? CriterionHScore { get; set; }


        [DisplayName("Skår I-kriteriet")]
        [Description("Artens delkategori (1-4) på I-kriteriet, overføring av parasitter eller patogener til stedegen art")]
        public int? CriterionIScore { get; set; }

        [DisplayName("Artens levetid i Norge (beste anslag)")]
        [Description("Artens mediane levetid i norsk natur (beste anslag)")]
        public long? MedianLifetimeBestEstimate { get; set; }

        [DisplayName("Ekspansjonshastighet (beste anslag)")]
        [Description("Artens ekspansjonshastighet i norsk natur (beste anslag)")]
        public long? ExpansionSpeedBestEstimate { get; set; }

        [DisplayName("Geografisk variasjon i risiko")]
        [Description("Arter med en viss utstrekning i forekomstarealet kan, som en respons på ulike miljøbetingelser, ha ulik påvirkning i naturen. Spørsmålet viser til om arten kunne fått en lavere risikokategori i deler av sitt potensielle forekomstareal")]
        public string GeographicVariationInCategory { get; set; }

        [DisplayName("Årsak til geografisk variasjon i risiko")]
        [Description("Angitte årsaker for hvorfor arten vurderes til å ha geografisk variasjon i risiko")]
        public string GeographicalVariation { get; set; }

        [DisplayName("Klimaeffekter invasjonspotensial")]
        [Description("Angir om skåren på invasjonsaksen ville vært lavere i fravær av pågående eller framtidige klimaendringer")]
        public string ClimateEffectsInvasionPotential { get; set; }

        [DisplayName("Klimaeffekter økologisk effekt")]
        [Description("Angir om skåren på effektaksen ville vært lavere i fravær av pågående eller framtidige klimaendringer")]
        public string ClimateEffectsEcoEffect { get; set; }

        [DisplayName("Kjent forekomstareal")]
        [Description("Artens kjente forekomstareal i dag")]
        public int? AOOknown { get; set; }

        [DisplayName("Antatt forekomstareal beste anslag")]
        [Description("Artens antatte forekomstareal i dag (beste anslag)")]
        public int? AOOtotalBest { get; set; }

        [DisplayName("Fremtidig forekomstareal beste anslag")]
        [Description("Artens antatte forekomstareal (beste anslag) ti år etter første introduksjon (dørstokkarter) eller om 50 år (selvstendig reproduserende arter)")]
        public int? AOOfutureBest { get; set; }

        [DisplayName("Ant. forekomster fra én introduksjon beste anslag")]
        [Description("Antallet forekomster (2 km x 2 km-ruter) dørstokkarten kan kolonisere i løpet av en 10 års-periode basert på én introduksjon til norsk natur (beste anslag)")]
        public int? Occurrences1Best { get; set; }

        [DisplayName("Ant. ytterligere introduksjoner beste anslag")]
        [Description("Antallet ytterligere introduksjoner til norsk natur dørstokkarten antas å få i løpet av en 10 års-periode (beste anslag)")]
        public int? IntroductionsBest { get; set; }

        [DisplayName("Naturtyper")]
        [Description("Naturtyper arten koloniserer eller påvirker i dag, eller forventes å kolonisere/påvirke i løpet av vurderingsperioden")]
        public string Ecosystems { get; set; }
    }
}
