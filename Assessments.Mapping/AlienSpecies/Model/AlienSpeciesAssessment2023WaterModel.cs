using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023WaterModel
    {
        /// <summary>
        /// TODO: documentation
        /// </summary>
        public bool IsWaterArea { get; set; }

        /// <summary>
        /// TODO: documentation
        /// </summary>
        public List<AlienSpeciesAssessment2023WaterArea> WaterAreas { get; set; } = new();
    }
}