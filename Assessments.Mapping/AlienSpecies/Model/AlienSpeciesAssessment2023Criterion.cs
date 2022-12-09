using System.Collections.Generic;
using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023Criterion
    {
        public AlienSpeciesAssessment2023CriteriaLetter CriteriaLetter { get; set; }

        public int Value { get; set; }

        public List<int> UncertaintyValues { get; set; }
    }
}