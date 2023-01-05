using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Shared.Helpers;
using System.Collections.Generic;
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
                AlienStatusExplanation = assessment.AlienSpeciesDescription,
                Category = assessment.Category,
                ChangedFromAlienDescription = assessment.ChangedFromAlienDescription,
                ConnectedToHigherLowerTaxonDescription = assessment.ConnectedToHigherLowerTaxonDescription,
                CriteriaDocumentation = assessment.RiskAssessmentCriteriaDocumentation,
                CriteriaDocumentationDomesticSpread = assessment.RiskAssessmentCriteriaDocumentationDomesticSpread,
                CriteriaDocumentationEcoEffect = assessment.RiskAssessmentCriteriaDocumentationEcoEffect,
                CriteriaDocumentationInvasionPotential = assessment.RiskAssessmentCriteriaDocumentationInvasionPotential,
                CriteriaDocumentationSpeciesStatus = assessment.RiskAssessmentCriteriaDocumentationSpeciesStatus,
                ChangedFromAlien = assessment.ChangedFromAlien,
                HasIndoorProduction = assessment.HasIndoorProduction,
                MisidentifiedDescription = assessment.MisIdentifiedDescription,
                SpreadFurtherSpreadFurtherInfo = assessment.SpreadFurtherSpreadFurtherInfo,
                SpreadIndoorFurtherInfo = assessment.SpreadIndoorFurtherInfo,
                Summary = assessment.RiskAssessmentGeographicalVariationDocumentation,
                TaxonRank = assessment.ScientificNameRank,
                UncertaintyEstablishmentTimeDescription = assessment.UncertaintyEstablishmentTimeDescription,
                UncertaintyStatusDescription = assessment.UncertaintyStatusDescription
            };

            RegionalSpreadViewModel = new RegionalSpreadViewModel
            {
                AlienSpeciesCategory = assessment.AlienSpeciesCategory,
                AreaOfOccupancyFutureBest = assessment.AOOfutureBest,
                AreaOfOccupancyFutureHigh = assessment.RiskAssessmentAOOfutureHigh,
                AreaOfOccupancyFutureLow = assessment.RiskAssessmentAOOfutureLow,
                AreaOfOccupancyTotalBest = assessment.AOOtotalBest,
                AreaOfOccupancyTotalHigh = assessment.RiskAssessmentAOOtotalHigh,
                AreaOfOccupancyTotalLow = assessment.RiskAssessmentAOOtotalLow,
                AreaOfOccupancyKnown = assessment.RiskAssessmentAOOknown,
                RiskAssessmentIntroductionsLow = assessment.RiskAssessmentIntroductionsLow,
                RiskAssessmentIntroductionsBest = assessment.RiskAssessmentIntroductionsBest,
                RiskAssessmentIntroductionsHigh = assessment.RiskAssessmentIntroductionsHigh,
                RiskAssessmentOccurrences1Low = assessment.RiskAssessmentOccurrences1Low,
                RiskAssessmentOccurrences1Best = assessment.RiskAssessmentOccurrences1Best,
                RiskAssessmentOccurrences1High = assessment.RiskAssessmentOccurrences1High,
                Category = assessment.Category,
                CurrentPresenceComment = assessment.CurrentPresenceComment,
                RegionOccurrences = assessment.RegionOccurrences
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

        public RegionalSpreadViewModel RegionalSpreadViewModel { get; set; }

        public SideBarContentViewModel SideBarContentViewModel { get; set; }

        public List<AlienSpeciesAssessment2023ExpertGroupMember> ExpertGroupMembers { get; set; } = new();
    }
}