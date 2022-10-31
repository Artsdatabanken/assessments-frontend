using Assessments.Mapping.AlienSpecies;
using Assessments.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class Areas
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023Areas =
            new List<AlienSpeciesAssessment2023EvaluationContext>(
                    (AlienSpeciesAssessment2023EvaluationContext[])Enum.GetValues(typeof(AlienSpeciesAssessment2023EvaluationContext)))
                .Select(x => new Filter.FilterItem
                {
                    Name = x.DisplayName(),
                    NameShort = x.ToString()
                }).ToArray();
    }
}
