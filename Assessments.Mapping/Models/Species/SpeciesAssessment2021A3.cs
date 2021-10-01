using System.Collections.Generic;

namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021A3
    {
        /// <summary>
        /// The basis of reduction on A3 is one or several of: (b) an index of abundance appropriate to the taxon, (c) a decline in area of occupancy, extent of occurrence and/or quality of habitat, (d) actual or potential levels of exploitation, and (e) the effects of introduced taxa, hybridization, pathogens, pollutants, competitors or parasites.
        /// </summary>
        public List<string> ReductionBasedOn { get; set; } = new(); // A3EndringBasertpåKode

        /// <summary>
        /// Preliminary category from evaluation against the A3 criteria.
        /// </summary>
        public string PreliminaryCategory { get; set; } // A3Kommende10År

        public SpeciesAssessment2021MinMaxProbableIntervall QuantifiedReduction { get; set; } = new(); // A3Kommende10ÅrAntatt
    }
}