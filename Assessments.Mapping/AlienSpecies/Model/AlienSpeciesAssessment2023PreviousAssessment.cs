using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023PreviousAssessment
    {
        public int RevisionYear { get; set; } = 2018;

        public string AssessmentId { get; set; }

        public int RiskLevel { get; set; }

        /// <summary>
        /// Evaluation  'tag' for the species in 2018 or 2012
        /// </summary>
        public string MainCategory { get; set; }

        public string MainSubCategory { get; set; }

        public AlienSpeciesAssessment2023Category Category { get; set; }

        public string Url { get; set; }
    }
}