using System.Collections.Generic;

namespace Assessments.Mapping.RedlistSpecies
{
    public class SpeciesAssessment2021A1
    {
        /// <summary>
        /// The basis of reduction on A1 is one or several of: (a) direct observation, (b) an index of abundance appropriate to the taxon, (c) a decline in area of occupancy, extent of occurrence and/or quality of habitat, (d) actual or potential levels of exploitation, and (e) the effects of introduced taxa, hybridization, pathogens, pollutants, competitors or parasites.
        /// </summary>
        public List<string> ReductionBasedOn { get; set; } = new(); // A1EndringBasertpåKode
        
        /// <summary>
        /// Preliminary category from evaluation against the A1 criteria.
        /// </summary>
        public string PreliminaryCategory { get; set; } // A1OpphørtOgReversibel
         
        public SpeciesAssessment2021MinMaxProbableIntervall QuantifiedReduction { get; set; } = new();  // A1OpphørtOgReversibelAntatt
    }
}