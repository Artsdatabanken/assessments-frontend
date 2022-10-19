using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies
{
    public class AlienSpeciesAssessment2023
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The scientific name. When forming part of an Identification, this should be the name in lowest level taxonomic rank that can be determined.
        /// </summary>
        public string ScientificName { get; set; }

        public string AlienSpeciesCategory { get; set; }

        public string Category { get; set; }

        public string EvaluationContext { get; set; }

        public string EvaluatedVernacularName { get; set; }

        public int? EvaluatedScientificNameId { get; set; }

        public List<AlienSpeciesAssessment2023PreviousAssessment> PreviousAssessments { get; set; } = new();
    }

    public class AlienSpeciesAssessment2023PreviousAssessment
    {
        public int RevisionYear { get; set; } = 2018;

        public string AssessmentId { get; set; }

        public string MainCategory { get; set; }
    }
}