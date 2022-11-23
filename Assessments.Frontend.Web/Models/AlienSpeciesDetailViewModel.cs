using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Shared.Helpers;
using System.Linq;

namespace Assessments.Frontend.Web.Models
{
    public class AlienSpeciesDetailViewModel
    {
        public AlienSpeciesDetailViewModel(AlienSpeciesAssessment2023 assessment)
        {
            Assessment = assessment;

            ExpertStatementViewModel = new ExpertStatementViewModel
            {
                AlienSpeciesCategory = assessment.AlienSpeciesCategory,
                AlienStatusExplanation = assessment.IsAlien,
                Category = assessment.Category,
                ChangedFromAlienDescription = assessment.ChangedFromAlienDescription,
                ConnectedToHigherLowerTaxonDescription = assessment.ConnectedToHigherLowerTaxonDescription,
                CriteriaDocumentation = assessment.RiskAssessmentCriteriaDocumentation,
                CriteriaDocumentationDomesticSpread = assessment.RiskAssessmentCriteriaDocumentationDomesticSpread,
                CriteriaDocumentationEcoEffect = assessment.RiskAssessmentCriteriaDocumentationEcoEffect,
                CriteriaDocumentationInvationPotential = assessment.RiskAssessmentCriteriaDocumentationInvationPotential,
                CriteriaDocumentationSpeciesStatus = assessment.RiskAssessmentCriteriaDocumentationSpeciesStatus,
                ChangedFromAlien = assessment.ChangedFromAlien,
                HasIndoorProduction = assessment.HasIndoorProduction,
                SpreadFurtherSpreadFurtherInfo = assessment.SpreadFurtherSpreadFurtherInfo,
                SpreadIntroductionFurtherInfo = assessment.SpreadIntroductionFurtherInfo,
                SpreadIndoorFurtherInfo = assessment.SpreadIndoorFurtherInfo,
                Summary = assessment.RiskAssessmentGeographicalVariationDocumentation,
                TaxonRank = assessment.ScientificNameRank,
                UncertaintyEstablishmentTimeDescription = assessment.UncertaintyEstablishmentTimeDescription,
                UncertaintyStatusDescription = assessment.UncertaintyStatusDescription
            };

            SideBarContentViewModel = new SideBarContentViewModel
            {
                AssessmentYear = 2023,
                Category = assessment.Category.DisplayName(),
                CategoryShort = assessment.Category.ToString(),
                PreviousAssessments = assessment.PreviousAssessments!.Select(x => new SideBarContentViewModel.SideBarPreviousAssessment
                {
                    Category = x.Category.DisplayName(),
                    CategoryShort = x.Category.ToString(),
                    Url = x.Url,
                    Year = x.RevisionYear
                }).ToArray(),
                ScientificName = assessment.ScientificName,
                ScientificNameId = assessment.ScientificNameId,
                TaxonRank = assessment.ScientificName // TODO: get scientificNameRank when it exists in the model
            };
        }

        public AlienSpeciesAssessment2023 Assessment { get; set; }

        public ExpertStatementViewModel ExpertStatementViewModel { get; set; }

        public SideBarContentViewModel SideBarContentViewModel { get; set; }
    }
}