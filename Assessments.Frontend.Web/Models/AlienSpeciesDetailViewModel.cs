using Assessments.Frontend.Web.Infrastructure;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
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

            AttachmentViewModel = new AttachmentViewModel
            {
                Attachments = assessment.Attachments,
                IsEvaluatedAtAnotherLever = assessment.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.TaxonEvaluatedAtAnotherLevel
            };

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
                EvaluationContext = assessment.EvaluationContext,
                HasIndoorProduction = assessment.HasIndoorProduction,
                ImportPathways = assessment.ImportPathways,
                MisidentifiedDescription = assessment.MisIdentifiedDescription,
                RaceViewModel = new RaceViewModel
                {
                    NameHierarchy = assessment.NameHiearchy,
                    ScientificName = assessment.ScientificName,
                    SpeciesGroup = assessment.SpeciesGroup,
                    VernacularName = assessment.VernacularName
                },
                References = assessment.References.Select(x => new CommonSimpleReference
                {
                    ReferenceId = x.ReferenceId,
                    FormattedReference = x.FormattedReference,
                    Type = x.Type
                }).ToList(),
                SpreadFurtherSpreadFurtherInfo = assessment.SpreadFurtherSpreadFurtherInfo,
                SpreadIndoorFurtherInfo = assessment.SpreadIndoorFurtherInfo,
                SpreadIntroductionFurtherInfo = assessment.SpreadIntroductionFurtherInfo,
                Summary = assessment.GeographicalVariationDocumentation,
                TaxonRank = assessment.ScientificName.ScientificNameRank,
                UncertaintyEstablishmentTimeDescription = assessment.UncertaintyEstablishmentTimeDescription,
                UncertaintyStatusDescription = assessment.UncertaintyStatusDescription
            };

            PageMenuViewModel = new PageMenuViewModel
            {
                AssessmentType = Assessments.Frontend.Web.Infrastructure.Enums.AssessmentType.AlienSpecies2023,
                PageMenuContentId = Constants.AlienSpecies2023PageMenuContentId,
                PageMenuExpandButtonText = Constants.AlienSpecies2023PageManuExpandButtonText,
                PageMenuHeaderText = Constants.AlienSpecies2023PageMenuHeaderText
            };

            ReferenceViewModel = new ReferenceViewModel
            {
                HasBackToTopLink = true,
                References = assessment.References.Select(x => new CommonSimpleReference
                {
                    ReferenceId = x.ReferenceId,
                    FormattedReference = x.FormattedReference,
                    Type = x.Type
                }).ToList()
            };

            RegionalSpreadViewModel = new RegionalSpreadViewModel
            {
                AlienSpeciesCategory = assessment.AlienSpeciesCategory,
                AreaOfOccupancyFutureBest = assessment.AOOfutureBest,
                AreaOfOccupancyFutureHigh = assessment.RiskAssessmentAOOfutureHigh,
                AreaOfOccupancyFutureLow = assessment.RiskAssessmentAOOfutureLow,
                AreaOfOccupancyKnown = assessment.AOOknown,
                AreaOfOccupancyTotalBest = assessment.AOOtotalBest,
                AreaOfOccupancyTotalHigh = assessment.AOOtotalHigh,
                AreaOfOccupancyTotalLow = assessment.AOOtotalLow,
                Category = assessment.Category,
                CurrentPresenceComment = assessment.CurrentPresenceComment,
                IsSvalbard = assessment.EvaluationContext == AlienSpeciesAssessment2023EvaluationContext.S,
                NameRank = assessment.ScientificName.ScientificNameRank,
                RegionOccurrences = assessment.RegionOccurrences,
                FreshWaterRegionModel = assessment.FreshWaterRegionModel,
                RiskAssessmentIntroductionsLow = assessment.RiskAssessmentIntroductionsLow,
                RiskAssessmentIntroductionsBest = assessment.RiskAssessmentIntroductionsBest,
                RiskAssessmentIntroductionsHigh = assessment.RiskAssessmentIntroductionsHigh,
                RiskAssessmentOccurrences1Low = assessment.RiskAssessmentOccurrences1Low,
                RiskAssessmentOccurrences1Best = assessment.RiskAssessmentOccurrences1Best,
                RiskAssessmentOccurrences1High = assessment.RiskAssessmentOccurrences1High
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
                ScientificName = assessment.ScientificName.ScientificName,
                ScientificNameId = assessment.ScientificName.ScientificNameId.Value,
                TaxonRank = assessment.ScientificName.ScientificNameRank // TODO: get scientificNameRank when it exists in the model
            };
        }

        public AlienSpeciesAssessment2023 Assessment { get; set; }

        public AttachmentViewModel AttachmentViewModel { get; set; }

        public ExpertStatementViewModel ExpertStatementViewModel { get; set; }

        public PageMenuViewModel PageMenuViewModel { get; set; }

        public ReferenceViewModel ReferenceViewModel { get; set; }

        public RegionalSpreadViewModel RegionalSpreadViewModel { get; set; }

        public SideBarContentViewModel SideBarContentViewModel { get; set; }

        public List<AlienSpeciesAssessment2023ExpertGroupMember> ExpertGroupMembers { get; set; } = new();
    }
}