using Assessments.Mapping.AlienSpecies;
using Assessments.Shared.Helpers;
using System;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class Areas
    {
        public static readonly Filter.FilterItem[] AlienSpecies2023Areas = Enum.GetValues<AlienSpeciesAssessment2023EvaluationContext>()
            .Select(x => new Filter.FilterItem
            {
                Name = x.DisplayName(),
                NameShort = x.ToString()
            }).ToArray();
    }
}