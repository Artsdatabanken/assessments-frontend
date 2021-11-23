using System.ComponentModel;

namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021Export
    {
        [DisplayName("Id for vurderingen")]
        [Description("Id for 2021 vurderingen")]
        public int Id { get; set; }
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
        
        [DisplayName("Vitenskapelig navn id")]
        [Description("Gyldig vitenskapelig navn id ved vurderingstidspunkt, i henhold til Artsnavnebase")]
        public string ScientificNameId { get; set; }

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
        
        [DisplayName("Østfold")]
        [Description("Østfold - tilstedeværelse i regionen")]
        public string Ostfold { get; set; }

        [DisplayName("Oslo og Akershus")]
        [Description("Oslo og Akershus - tilstedeværelse i regionen")]
        public string OsloOgAkershus { get; set; }

        [DisplayName("Hedmark")]
        [Description("Hedmark - tilstedeværelse i regionen")]
        public string Hedmark { get; set; }

        [DisplayName("Oppland")]
        [Description("Oppland - tilstedeværelse i regionen")]
        public string Oppland { get; set; }

        [DisplayName("Buskerud")]
        [Description("Buskerud - tilstedeværelse i regionen")]
        public string Buskerud { get; set; }

        [DisplayName("Vestfold")]
        [Description("Vestfold - tilstedeværelse i regionen")]
        public string Vestfold { get; set; }

        [DisplayName("Telemark")]
        [Description("Telemark - tilstedeværelse i regionen")]
        public string Telemark { get; set; }

        [DisplayName("Aust-Agder")]
        [Description("Aust-Agder - tilstedeværelse i regionen")]
        public string AustAgder { get; set; }

        [DisplayName("Vest-Agder")]
        [Description("Vest-Agder - tilstedeværelse i regionen")]
        public string VestAgder { get; set; }

        [DisplayName("Rogaland")]
        [Description("Rogaland - tilstedeværelse i regionen")]
        public string Rogaland { get; set; }

        [DisplayName("Hordaland")]
        [Description("Hordaland - tilstedeværelse i regionen")]
        public string Hordaland { get; set; }

        [DisplayName("Sogn og Fjordane")]
        [Description("Sogn og Fjordane - tilstedeværelse i regionen")]
        public string SognOgFjordane { get; set; }

        [DisplayName("Møre og Romsdal")]
        [Description("Møre og Romsdale - tilstedeværelse i regionen")]
        public string MoreOgRomsdal { get; set; }

        [DisplayName("Trøndelag")]
        [Description("Trøndelag - tilstedeværelse i regionen")]
        public string Trondelag { get; set; }

        [DisplayName("Nordland")]
        [Description("Nordland - tilstedeværelse i regionen")]
        public string Nordland { get; set; }

        [DisplayName("Troms")]
        [Description("Troms - tilstedeværelse i regionen")]
        public string Troms { get; set; }

        [DisplayName("Finnmark")]
        [Description("Finnmark - tilstedeværelse i regionen")]
        public string Finnmark { get; set; }

        [DisplayName("Jan Mayen")]
        [Description("Jan Mayen - tilstedeværelse i regionen")]
        public string JanMayen { get; set; }
        
        [DisplayName("Nordsjøen")]
        [Description("Nordsjøen - tilstedeværelse i regionen")]
        public string Nordsjoen { get; set; }
        
        [DisplayName("Norskehavet")]
        [Description("Norskehavet - tilstedeværelse i regionen")]
        public string Norskehavet { get; set; } 
        
        [DisplayName("Barentshavet nord og Polhavet")]
        [Description("Barentshavet nord og Polhavet - tilstedeværelse i regionen")]
        public string BarentshavetNordOgPolhavet { get; set; }
        
        [DisplayName("Barentshavet sør")]
        [Description("Barentshavet sør - tilstedeværelse i regionen")]
        public string BarentshavetSor { get; set; } 
        
        [DisplayName("Grønlandshavet")]
        [Description("Grønlandshavet - tilstedeværelse i regionen")]
        public string Gronlandshavet { get; set; }

    }
}