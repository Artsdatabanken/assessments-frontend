namespace Assessments.Mapping.Models.Species
{
    // TODO: add (more) documentation?
    public class SpeciesAssessment2021TaxonHistory
    {
        public string ExpertCommittee { get; set; } // Ekspertgruppe

        public int TaxonId { get; set; }

        /// <summary>
        /// Taxonomic level for the assessment
        /// </summary>
        public string TaxonRank { get; set; }

        public string ScientificName { get; set; } // VitenskapeligNavn

        public string AuthorCitation { get; set; } // VitenskapeligNavnAutor

        public string TaxonomicHierarchy { get; set; } // VitenskapeligNavnHierarki

        public int ScientificNameId { get; set; } // VitenskapeligNavnId
    }
}