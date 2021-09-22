using System.ComponentModel;

namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021Export
    {
        [DisplayName("Vurderingsområde")]
        [Description("Er arten vurdert for Norge eller Svalbard")]
        public string AssessmentArea { get; set; }

        [DisplayName("Ekspertkomité")]
        [Description("Hvilken ekspertkomité som har gjort vurderingen")]
        public string ExpertCommittee { get; set; }

        [DisplayName("Artsgruppe")]
        [Description("Artsgruppenavn")]
        public string SpeciesGroup { get; set; }

        [DisplayName("Taksonomisk sti")]
        [Description("Taksonomisk sti for arten")]
        public string VurdertVitenskapeligNavnHierarki { get; set; }

        [DisplayName("Vitenskapelig navn")]
        [Description("Gyldig vitenskapelig navn ved vurderingstidspunkt, i henhold til Artsnavnebase")]
        public string ScientificName { get; set; }

        [DisplayName("Autor")]
        [Description("Autor for vitenskapelig navn")]
        public string ScientificNameAuthor { get; set; }

        [DisplayName("Populærnavn")]
        [Description("Prioritert norsk populærnavn i henhold til Artsnavnebase")]
        public string PopularName { get; set; }

        [DisplayName("Taksonomisk nivå")]
        [Description("Om vurderingen er på artsnivå (species) eller under artsnivået (subspecies). Merk at subspecies også inneholder varieteter i tillegg til underarter")]
        public string TaxonRank { get; set; }

        [DisplayName("Årstall for siste revisjon")]
        [Description("År for nyeste revisjon")]
        public string AssessmentYear { get; set; }

        [DisplayName("Kategori 2021")]
        [Description("Kategori 2021")]
        public string Category { get; set; }

        [DisplayName("Kriterier 2021")]
        [Description("Utslagsgivende kriterier 2021")]
        public string CriteriaSummarized { get; set; }

        [DisplayName("Kriteriedokumentasjon")]
        [Description("Dokumentasjonstekst for vurderingen")]
        public string ExpertStatement { get; set; }

        [DisplayName("Begrunnelse nedgradering av kategori")] 
        [Description("Dokumentasjonstekst dersom risiko for utdøing sterkt påvirket av populasjoner i naboland")] 
        public string RationaleCategoryAdjustment { get; set; }

        [DisplayName("Risiko for utdøing sterkt påvirket av populasjoner i naboland")]
        [Description("Om risiko for utdøing blir sterkt påvirket av populasjoner i naboland")]
        public string ExtinctionRiskAffected { get; set; }

        [DisplayName("Er arten trolig utdødd")]
        [Description("Merkelapp til kritisk truet CR-kategorien. Ikke en egen kategori, men kan brukes dersom ekspertene tror en art er utdødd, men kravene til regionalt utdødd RE ikke er oppfylt")]
        public string PresumedExtinct { get; set; }

        [DisplayName("Begrunnelse for endring av kategori")]
        [Description("Kort forklaring dersom arten har en annen kategori i 2021 sammenlignet med 2015")]
        public string ReasonCategoryChange { get; set; }

        [DisplayName("Kategori 2015")]
        [Description("Kategori 2015")]
        public string Category2015 { get; set; }

        [DisplayName("Kriterier 2015")]
        [Description("Utslagsgivende kriterier 2015")]
        public string CriteriaSummarized2015 { get; set; }

        [DisplayName("Kategori 2010")]
        [Description("Kategori 2010")]
        public string Category2010 { get; set; }

        [DisplayName("Kriterier 2010")]
        [Description("Utslagsgivende kriterier 2010")]
        public string CriteriaSummarized2010 { get; set; }
        
        [DisplayName("Andel av europeisk populasjon i Norge")]
        [Description("Andelen den norske populasjonen utgjør at europeisk populasjon. Predefinerte intervaller")]
        public string PercentageEuropeanPopulation { get; set; }

        [DisplayName("Andel av global populasjon i Norge")]
        [Description("Andelen den norske populasjonen utgjør at global populasjon. Predefinerte intervaller")]
        public string PercentageGlobalPopulation { get; set; }

        [DisplayName("Nåværende bestand som andel av maks. bestand")]
        [Description("Andelen den norske populasjonen utgjør i dag sammenlignet med maks populasjonsstørrelse siden år 1900. Predefinerte intervaller")]
        public string ProportionOfMaxPopulation { get; set; }

        [DisplayName("Hovedhabitat")]
        [Description("ovedhabitatet arten er tilknyttet til, definert ut fra NiN 2.0. Les mer i vedlegg 2 i Veileder til rødlistevurdering for Norsk rødliste for arter 2021")]
        public string MainHabitat { get; set; }

        [DisplayName("Påvirkningsfaktorer")]
        [Description("Påvirkningsfaktorer, skilletegn for ny påvirkningsfaktor er ;")]
        public string ImpactFactors { get; set; }

        //[DisplayName("")]
        //[Description("")]
        //public string Xxx { get; set; }
    }
}