using System;

namespace Assessments.Transformation.Database.Rodliste2020.Models
{
    public class Assessment
    { 
        public int Id { get; set; }
        public string Doc { get; set; }
        public string TaxonHierarcy { get; set; }
        public string LockedForEditByUser { get; set; }
        public string LastUpdatedBy { get; set; }
        public string Expertgroup { get; set; }
        public string EvaluationStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public string Category { get; set; }
        public DateTime? LockedForEditAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string ScientificName { get; set; }
        public int? ScientificNameId { get; set; }
        public string PopularName { get; set; }
        public string Criteria { get; set; }
        public string AssessmentContext { get; set; }
        public string CategoryLastRedList { get; set; }
        public string NatureTypes { get; set; }
        public string RedListAssessedSpecies { get; set; }
        public int? AssessmentYear { get; set; }
    }
}
