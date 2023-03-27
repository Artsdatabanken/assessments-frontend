
using System.ComponentModel;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023Export
    {
        [DisplayName("Id for vurderingen")]
        [Description("Id for 2023 vurderingen")]
        public int Id { get; set; }

        [DisplayName("Ekspertkomité")]
        [Description("Ekspertgruppen bak 2023-vurderingen")]
        public string ExpertGroup { get; set; }

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

        [DisplayName("Skår Invasjonspotensial")]
        [Description("Artens delkategori (1-4) på invasjonsaksen i risikomatrisen. Denne bestemmes av artens invasjonspotensial")]
        public int? ScoreInvasionPotential { get; set; }

        [DisplayName("Skår Økologisk effekt")]
        [Description("Artens delkategori (1-4) på effektaksen i risikomatrisen. Denne bestemmes av artens økologiske effekt")]
        public int? ScoreEcologicalEffect { get; set; }

        [DisplayName("Estimeringsmetode A-kriteriet")]
        [Description("Valgt estimeringsmetode for A-kriteriet, artens mediane levetid i Norge")]
        public string MedianLifetimeEstimationMethod { get; set; }

        [DisplayName("Forenklet Anslag akseptert")]
        [Description("Er den automatisk estimerte utregningen av artens mediane levetid i Norge basert på metoden forenklet anslag akseptert?")]
        public bool? IsAcceptedSimplifiedEstimate { get; set; }

        [DisplayName("Estimeringsmetode B-kriteriet")]
        [Description("Valgt estimeringsmetode for B-kriteriet, artens ekspansjonshastighet i norsk natur")]
        public string ExpansionSpeedEstimationMethod { get; set; }

        [DisplayName("Ekspansjonshastighet (lavt anslag)")]
        [Description("Artens ekspansjonshastighet i norsk natur (lavt anslag)")]
        public long ExpansionSpeedLowEstimate { get; set; }

        [DisplayName("Ekspansjonshastighet (beste anslag)")]
        [Description("Artens ekspansjonshastighet i norsk natur (beste anslag)")]
        public long ExpansionSpeedBestEstimate { get; set; }

        [DisplayName("Ekspansjonshastighet (høyt anslag)")]
        [Description("Artens ekspansjonshastighet i norsk natur (høyt anslag)")]
        public long ExpansionSpeedHighEstimate { get; set; }

        [DisplayName("Geografisk variasjon i risiko")]
        [Description("Arter med en viss utstrekning i forekomstarealet kan, som en respons på ulike miljøbetingelser, ha ulik påvirkning i naturen. Spørsmålet viser til om arten kunne fått en lavere risikokategori i deler av sitt potensielle forekomstareal")]
        public bool? GeographicVariationInCategory { get; set; }

        [DisplayName("Årsak til geografisk variasjon i risiko")]
        [Description("Angitte årsaker for hvorfor arten vurderes til å ha geografisk variasjon i risiko")]
        public string GeographicalVariation { get; set; }

        [DisplayName("Geografisk variasjon i risiko Beskrivelse")]
        [Description("Nærmere begrunnelse for artens geografiske variasjon i risiko")]
        public string GeographicalVariationDocumentation { get; set; }

        [DisplayName("Klimaeffekter invasjonspotensial")]
        [Description("Angir om skåren på invasjonsaksen ville vært lavere i fravær av pågående eller framtidige klimaendringer")]
        public bool? ClimateEffectsInvasionPotential { get; set; }

        [DisplayName("Klimaeffekter økologisk effekt")]
        [Description("Angir om skåren på effektaksen ville vært lavere i fravær av pågående eller framtidige klimaendringer")]
        public bool? ClimateEffectsEcoEffect { get; set; }

        [DisplayName("Klimaeffekter Beskrivelse")]
        [Description("Nærmere begrunnelse for påvirkning av pågående eller framtidige klimaendringer på artens delkategori på aksene")]
        public string ClimateEffectsDocumentation { get; set; }

        [DisplayName("Risikokategori 2018")]
        [Description("Endelig kategori i 2018 etter GEIAAS kategorier and kriterier")]
        public string PreviousAssessmentCategory2018 { get; set; }

        [DisplayName("Kjent forekomstareal")]
        [Description("Artens kjente forekomstareal i dag")]
        public int? AOOknown { get; set; }

        [DisplayName("Antatt forekomstareal lavt anslag")]
        [Description("Artens antatte forekomstareal i dag (lavt anslag)")]
        public int? AOOtotalLow { get; set; }

        [DisplayName("Antatt forekomstareal beste anslag")]
        [Description("Artens antatte forekomstareal i dag (beste anslag)")]
        public int? AOOtotalBest { get; set; }

        [DisplayName("Antatt forekomstareal høyt anslag")]
        [Description("Artens antatte forekomstareal i dag (høyt anslag)")]
        public int? AOOtotalHigh { get; set; }

        //TODO: skill felt mellom dørstokkarter og selvstendig reproduserende for fremtidige forekomstareal?
        [DisplayName("Fremtidig forekomstareal lavt anslag")]
        [Description("Artens antatte forekomstareal (lavt anslag) ti år etter første introduksjon (dørstokkarter) eller om 50 år (selvstendig reproduserende arter)")]
        public int? RiskAssessmentAOOfutureLow { get; set; }

        [DisplayName("Fremtidig forekomstareal beste anslag")]
        [Description("Artens antatte forekomstareal (beste anslag) ti år etter første introduksjon (dørstokkarter) eller om 50 år (selvstendig reproduserende arter)")]
        public int? AOOfutureBest { get; set; }

        [DisplayName("Fremtidig forekomstareal høyt anslag")]
        [Description("Artens antatte forekomstareal (beste anslag) ti år etter første introduksjon (dørstokkarter) eller om 50 år (selvstendig reproduserende arter)")]
        public int? RiskAssessmentAOOfutureHigh { get; set; }

        [DisplayName("Ant. forekomster fra én introduksjon lavt anslag")]
        [Description("Antallet forekomster (2 km x 2 km-ruter) dørstokkarten kan kolonisere i løpet av en 10 års-periode basert på én introduksjon til norsk natur (lavt anslag)")]
        public int? RiskAssessmentOccurrences1Low { get; set; }

        [DisplayName("Ant. forekomster fra én introduksjon beste anslag")]
        [Description("Antallet forekomster (2 km x 2 km-ruter) dørstokkarten kan kolonisere i løpet av en 10 års-periode basert på én introduksjon til norsk natur (beste anslag)")]
        public int? RiskAssessmentOccurrences1Best { get; set; }

        [DisplayName("Ant. forekomster fra én introduksjon høyt anslag")]
        [Description("Antallet forekomster (2 km x 2 km-ruter) dørstokkarten kan kolonisere i løpet av en 10 års-periode basert på én introduksjon til norsk natur (høyt anslag)")]
        public int? RiskAssessmentOccurrences1High { get; set; }

        [DisplayName("Ant. ytterligere introduksjoner lavt anslag")]
        [Description("Antallet ytterligere introduksjoner til norsk natur dørstokkarten antas å få i løpet av en 10 års-periode (lavt anslag)")]
        public int? RiskAssessmentIntroductionsLow { get; set; }

        [DisplayName("Ant. ytterligere introduksjoner beste anslag")]
        [Description("Antallet ytterligere introduksjoner til norsk natur dørstokkarten antas å få i løpet av en 10 års-periode (beste anslag)")]
        public int? RiskAssessmentIntroductionsBest { get; set; }

        [DisplayName("Ant. ytterligere introduksjoner høyt anslag")]
        [Description("Antallet ytterligere introduksjoner til norsk natur dørstokkarten antas å få i løpet av en 10 års-periode (høyt anslag)")]
        public int? RiskAssessmentIntroductionsHigh { get; set; }

        [DisplayName("Kom til vurderingsområdet fra")]
        [Description("Angir hvorfra arten ankom vurderingsområdet")]
        public string ArrivedCountryFrom { get; set; }

        [DisplayName("Naturtyper")]
        [Description("Naturtyper arten koloniserer eller påvirker i dag, eller forventes å kolonisere/påvirke i løpet av vurderingsperioden")]
        public string Ecosystems { get; set; }
    }
}
