namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023FreshWaterRegion
    {
        /// <summary>
        /// TODO: documentation
        /// </summary>
        public string WaterRegionId { get; set; }

        /// <summary>
        /// TODO: documentation
        /// </summary>
        public string GlobalId { get; set; }

        /// <summary>
        /// Norwegian name to water region
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is the water region included in the assessment area, i.e. is the species regarded regionally alien to the region (if false, the species is native to the region)
        /// </summary>
        public bool IsIncludedInAssessmentArea { get; set; }

        /// <summary>
        /// Is the species known to occur in the water region
        /// </summary>
        public bool IsKnown { get; set; }

        /// <summary>
        /// Is the species assumed to occur in the water region today
        /// </summary>
        public bool IsAssumedToday { get; set; }

        /// <summary>
        ///  Is the species assumed to occur in the water region in the future (within 50 years)
        /// </summary>
        public bool IsAssumedInFuture { get; set; }
    }
}