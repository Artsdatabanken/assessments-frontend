using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023RiskAssessment
    {
        /// <summary>
        /// Wether the species' score on the effect axis would be lower in the absence of current or future climate changes 
        /// </summary>
        public bool? ClimateEffectsEcoEffect { get; set; }

        /// <summary>
        /// Further information about the effects of current or future climate changes 
        /// </summary>
        public string ClimateEffectsDocumentation { get; set; }

        /// <summary>
        /// Wether the species' score on the invation axis would be lower in the absence of current or future climate changes 
        /// </summary>
        public bool? ClimateEffectsInvationpotential { get; set; }

        /// <summary>
        /// Potential causes for the geographic variance in category. List containing up to 4 elements 
        /// </summary>
        public string[] GeographicalVariation { get; set; }

        /// <summary>
        /// Further information about the geographic variance in category 
        /// </summary>
        public string GeographicalVariationDocumentation { get; set; }

        /// <summary>
        /// Wether the species has a lower impact category in parts of the species’ range
        /// </summary>
        public bool? GeographicVariationInCategory { get; set; }

        

        
    }
}