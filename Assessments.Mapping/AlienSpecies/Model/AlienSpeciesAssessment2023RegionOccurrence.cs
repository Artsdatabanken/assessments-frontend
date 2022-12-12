using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023RegionOccurrence 
    {
        public AlienSpeciesAssessment2023Region Region { get; set; }

        /// <summary>
        /// TODO: documentation (State0)
        /// </summary>
        public bool IsKnown { get; set; }

        /// <summary>
        /// TODO: documentation (State1)
        /// </summary>
        public bool IsAssumedToday { get; set; }

        /// <summary>
        /// TODO: documentation (State3)
        /// </summary>
        public bool IsAssumedInFuture { get; set; }
    }
}