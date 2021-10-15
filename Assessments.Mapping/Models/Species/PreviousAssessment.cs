namespace Assessments.Mapping.Models.Species
{
    public class PreviousAssessment
    {
        /// <summary>
        /// Year of assessment
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Final category according to IUCN categories and criteria.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Criteria summarized according to IUCN Guidelines and Norwegian national adaptations, written on the standard IUCN format. 
        /// </summary>
        public string CriteriaSummarized { get; set; }

        public string AssessmentUrl{ get; set; }
        public int ScientificNameId { get; set; }
        public string ScientificName { get; set; }

    }
}