using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023FreshWaterRegionModel
    {
        /// <summary>
        /// Is the fresh water regions splitted in many small-scale water areas (true) or in fewer large-scale, county-like water regions (false)
        /// </summary>
        public bool IsWaterArea { get; set; }

        /// <summary>
        /// List including all water areas or water regions, and information about the species "occurrence-status" in each region  
        /// </summary>
        public List<AlienSpeciesAssessment2023FreshWaterRegion> FreshWaterRegions { get; set; } = new();
    }
}