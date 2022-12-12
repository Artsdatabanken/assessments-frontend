using System.Collections.Generic;
using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    /// <summary>
    /// TODO: documentation
    /// </summary>
    public class AlienSpeciesAssessment2023Criterion
    {
        /// <summary>
        /// TODO: documentation
        /// </summary>
        public AlienSpeciesAssessment2023CriteriaLetter CriteriaLetter { get; set; }

        /// <summary>
        /// TODO: documentation
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// TODO: documentation
        /// </summary>
        public List<int> UncertaintyValues { get; set; }
    }
}