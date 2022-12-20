using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessments.Mapping.AlienSpecies.Helpers;

namespace Assessments.Tests.Mapping.Helpers
{
    public class GetMedianLifetimeSimplifiedEstimationDefaultScoreBestTest
    {
        [Fact]
        public void StripHtmlExtensionShouldRemoveHtml()
        {
            var testAssessment = new Assessments.Mapping.AlienSpecies.Source.RiskAssessment();
            testAssessment.AOO50yrBestInput = 20;
            testAssessment.AOOtotalBestInput = 40;

            var result = AlienSpeciesAssessment2023ProfileHelper.GetMedianLifetimeSimplifiedEstimationDefaultScoreBest("NotAssessedDoorknocker", testAssessment);
            Assert.Equal(4, result);
        }

    }
}
