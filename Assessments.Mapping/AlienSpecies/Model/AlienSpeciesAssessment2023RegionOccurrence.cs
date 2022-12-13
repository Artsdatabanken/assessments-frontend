using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023RegionOccurrence 
    {
        public AlienSpeciesAssessment2023Region Region { get; set; }

        /// <summary>
        /// TODO: documentation
        /// </summary>
        public bool IsKnown { get; set; }

        /// <summary>
        /// TODO: documentation
        /// </summary>
        public bool IsAssumedToday { get; set; }

        /// <summary>
        /// TODO: documentation
        /// </summary>
        public bool IsAssumedInFuture { get; set; }
    }
}