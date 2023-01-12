using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023RegionOccurrence 
    {
        public AlienSpeciesAssessment2023Region Region { get; set; }

        /// <summary>
        /// Is the species known to occur in the region today
        /// </summary>
        public bool IsKnown { get; set; }

        /// <summary>
        /// Is the species assumed to occur in the region today
        /// </summary>
        public bool IsAssumedToday { get; set; }

        /// <summary>
        /// Is the species assumed to occur in the region in the future (within 50 years)
        /// </summary>
        public bool IsAssumedInFuture { get; set; }
    }
}