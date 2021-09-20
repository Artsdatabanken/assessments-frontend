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


        //[DisplayName("")]
        //[Description("")]
        //public string Xx { get; set; }
    }
}