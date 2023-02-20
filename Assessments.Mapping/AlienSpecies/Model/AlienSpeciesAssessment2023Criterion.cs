using System.Collections.Generic;
using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    /// <summary>
    /// List including all criteria (A-I), their score and uncertainty
    /// </summary>
    public class AlienSpeciesAssessment2023Criterion
    {
        /// <summary>
        /// Indicates the criteria by its letter A to I.
        /// </summary>
        public AlienSpeciesAssessment2023CriteriaLetter CriteriaLetter { get; set; }

        /// <summary>
        /// The score linked to the criteria. Takes a value 1-4 and indicates the most likely value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The uncertainty in the criteria's score. There is always incertainty within the range of a score (i.e. if Value is 4, UncertaintyValues includes the number 4). If length is > 1, the uncertainty goes beyond the range of the most likely score to a lower and/or higher score.
        /// </summary>
        public List<int> UncertaintyValues { get; set; }
    }
}