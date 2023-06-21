using Assessments.Frontend.Web.Infrastructure;
using Assessments.Mapping.AlienSpecies.Helpers;
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
                AllSubTaxaAssessedSeparately = assessment.AllSubTaxaAssessedSeparatelyDescription,
                AlienStatusExplanation = assessment.AlienSpeciesDescription,
                Category = assessment.Category,
                ChangedFromAlienDescription = assessment.ChangedFromAlienDescription,
                ConnectedToHigherLowerTaxonDescription = assessment.ConnectedToHigherLowerTaxonDescription,
                CriteriaDocumentation = assessment.CriteriaDocumentation,
                CriteriaDocumentationDomesticSpread = assessment.CriteriaDocumentationDomesticSpread,
                CriteriaDocumentationEcoEffect = assessment.CriteriaDocumentationEcoEffect,
                CriteriaDocumentationInvasionPotential = assessment.CriteriaDocumentationInvasionPotential,
                CriteriaDocumentationSpeciesStatus = assessment.CriteriaDocumentationSpeciesStatus,
                ChangedFromAlien = assessment.ChangedFromAlien,
                Environment = assessment.Environment,
                EvaluationContext = assessment.EvaluationContext,
                HasIndoorProduction = assessment.HasIndoorProduction,
                HybridWithoutOwnRiskAssessmentDescription = assessment.HybridWithoutOwnRiskAssessmentDescription,
                ImportPathways = assessment.ImportPathways,
                MisidentifiedDescription = assessment.MisIdentifiedDescription,
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
                AreaOfOccupancyFutureHigh = assessment.AOOfutureHigh,
                AreaOfOccupancyFutureLow = assessment.AOOfutureLow,
                AreaOfOccupancyInStronglyAlteredEcosystems = assessment.AreaOfOccupancyInStronglyAlteredEcosystems,
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
                RiskAssessmentIntroductionsLow = assessment.IntroductionsLow,
                RiskAssessmentIntroductionsBest = assessment.IntroductionsBest,
                RiskAssessmentIntroductionsHigh = assessment.IntroductionsHigh,
                RiskAssessmentOccurrences1Low = assessment.Occurrences1Low,
                RiskAssessmentOccurrences1Best = assessment.Occurrences1Best,
                RiskAssessmentOccurrences1High = assessment.Occurrences1High
            };

            SideBarContentViewModel = new SideBarContentViewModel
            {
                AssessmentType = Infrastructure.Enums.AssessmentType.AlienSpecies2023,
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
                ScientificNameId = (int)assessment.ScientificName.ScientificNameId,
                TaxonRank = assessment.ScientificName.ScientificNameRank, // TODO: get scientificNameRank when it exists in the model
                SpeciesIsOnBannedList = AlienSpeciesAssessment2023ProfileHelper.AlienSpeciesBanList().Contains(assessment.ScientificName.ScientificNameId.Value)
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