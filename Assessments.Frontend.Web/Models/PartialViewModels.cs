using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using System;
using System.Collections.Generic;

namespace Assessments.Frontend.Web.Models
{
    public class AssessmentPageHeaderViewModel
    {
        public string AssessmentArea { get; set; }

        public ScientificNameViewModel ScientificNameViewModel { get; set; }

        public SpeciesGroupViewModel SpeciesGroupViewModel { get; set; }
    }

    public class CategoryBarListElement
    {
        public string Name { get; set; }

        public string NameShort { get; set; }
    }

    public class CategoryDescriptionViewModel
    {
        public string CategoryShort { get; set; }

        public CategoryBarListElement[] CategoryBar { get; set; }

        public string MethodUrl { get; set; }
    }

    public class CitationForAssessmentViewModel
    {
        public string AssessmentName { get; set; }

        public int AssessmentYear { get; set; }

        public string ExpertCommittee { get; set; }

        public string FirstPublished { get; set; }

        public string PublicationText { get; set; }

        public DateTime RevisionDate { get; set; }

        public string RevisionReason { get; set; }

        public int YearPreviousAssessment { get; set; }

        public string ExpertGroupMembers { get; set; }
    }

    public class CitationForListViewModel
    {
        public string CitationString { get; set; }
    }

    public class ControlButtonsViewModel
    {
        public string View { get; set; }

        public int ItemCount { get; set; }
    }

    public class ExpertStatementViewModel
    {
        public AlienSpeciecAssessment2023AlienSpeciesCategory AlienSpeciesCategory { get; set; }

        public string AlienStatusExplanation { get; set; }

        public AlienSpeciesAssessment2023Category Category { get; set; }

        public AlienSpeciesAssessment2023ChangedFromAlien ChangedFromAlien { get; set; }

        public string ChangedFromAlienDescription { get; set; }

        public string ConnectedToHigherLowerTaxonDescription { get; set; }

        public string CriteriaDocumentation { get; set; }

        public string CriteriaDocumentationDomesticSpread { get; set; }

        public string CriteriaDocumentationEcoEffect { get; set; }

        public string CriteriaDocumentationInvasionPotential { get; set; }

        public string CriteriaDocumentationSpeciesStatus { get; set; }

        public AlienSpeciesAssessment2023EvaluationContext EvaluationContext { get; set; }

        public bool HasIndoorProduction { get; set; }

        public List<AlienSpeciesAssessment2023AssessmentVector> ImportPathways { get; set; }

        public string MisidentifiedDescription { get; set; }

        public List<CommonSimpleReference> References { get; set; }

        public string SpreadFurtherSpreadFurtherInfo { get; set; }

        public string SpreadIntroductionFurtherInfo { get; set; }

        public string SpreadIndoorFurtherInfo { get; set; }

        public string Summary { get; set; }

        public AlienSpeciesAssessment2023TaxonRank TaxonRank { get; set; }

        public string UncertaintyStatusDescription { get; set; }

        public string UncertaintyEstablishmentTimeDescription { get; set; }
    }

    public class IngressViewModel
    {
        public AlienSpeciesAssessment2023Environment Environment { get; set; }

        public AlienSpeciesAssessment2023EvaluationContext EvaluationContext { get; set; }

        public AlienSpeciesAssessment2023Category Category { get; set; }

        public AlienSpeciecAssessment2023AlienSpeciesCategory AlienSpeciesCategory { get; set; }

        public string ListName { get; set; }

        public int? ParentAssessmentId { get; set; }

        public AlienSpeciesAssessment2023SpeciesStatus SpeciesStatus { get; set; }

        public string Status { get; set; }

        public AlienSpeciesAssessment2023TaxonRank TaxonRank { get; set; }
    }

    public class RegionalSpreadViewModel
    {
        public int? AreaOfOccupancyKnown { get; set; }

        public int? AreaOfOccupancyFutureBest { get; set; }

        public int? AreaOfOccupancyFutureHigh { get; set; }

        public int? AreaOfOccupancyFutureLow { get; set; }

        public int? AreaOfOccupancyTotalBest { get; set; }

        public int? AreaOfOccupancyTotalHigh { get; set; }

        public int? AreaOfOccupancyTotalLow { get; set; }

        public bool IsSvalbard { get; set; }

        public int? RiskAssessmentIntroductionsLow { get; set; }

        public int? RiskAssessmentIntroductionsBest { get; set; }

        public int? RiskAssessmentIntroductionsHigh { get; set; }

        public int? RiskAssessmentOccurrences1Low { get; set; }

        public int? RiskAssessmentOccurrences1Best { get; set; }

        public int? RiskAssessmentOccurrences1High { get; set; }


        public AlienSpeciecAssessment2023AlienSpeciesCategory AlienSpeciesCategory { get; set; }

        public AlienSpeciesAssessment2023Category Category { get; set; }

        public string CurrentPresenceComment { get; set; }

        public List<AlienSpeciesAssessment2023RegionOccurrence> RegionOccurrences { get; set; }
    }

    public class MapViewModel
    {
        public string MapName { get; set; }

        public string MapText { get; set; }

        public string MapDescription { get; set; }

        public List<AlienSpeciesAssessment2023RegionOccurrence> RegionOccurrences { get; set; }
    }

    public class ReferenceViewModel
    {
        public bool IsCollapsible { get; set; }

        public List<CommonSimpleReference> References { get; set; }
    }

    public class SideBarContentViewModel
    {
        public class SideBarPreviousAssessment
        {
            public string Category { get; set; }

            public string CategoryShort { get; set; }

            public string Url { get; set; }

            public int Year { get; set; }
        }

        public int AssessmentYear { get; set; }

        public string Category { get; set; }

        public string CategoryShort { get; set; }

        public string ScientificName { get; set; }

        public int ScientificNameId { get; set; }

        public SideBarPreviousAssessment[] PreviousAssessments { get; set; }

        public string TaxonRank { get; set; }
    }

    public class CommonSimpleReference
    {
        public string Type { get; set; }

        public Guid ReferenceId { get; set; }

        public string FormattedReference { get; set; }
    }

    public class HeaderViewModel
    {
        public string Title { get; set; }

        public string TitleShort { get; set; }
    }

    public class PageHeaderViewModel
    {
        public string HeaderText { get; set; }

        public string HeaderByline { get; set; }
    }

    public class IntroductionViewModel
    {
        public string Introduction { get; set; }
    }

    public class PageMenuViewModel
    {
        public int PageMenuContentId { get; set; }

        public string PageMenuExpandButtonText { get; set; }

        public string PageMenuHeaderText { get; set; }
    }

    public class ScientificNameViewModel
    {
        public string PopularName { get; set; }

        public string ScientificName { get; set; }

        public string ScientificNameAuthor { get; set; }
    }

    public class SidebarContentViewModel
    {
        public string ScientificName { get; set; }

        public int ScientificNameId { get; set; }

        public string TaxonRank { get; set; }
    }

    public class SpeciesGroupViewModel
    {
        public int AssessmentYear { get; set; }

        public string ExpertCommittee { get; set; }

        public string FirstPublishedDateString { get; set; }

        public int PreviousAssessmentYear { get; set; }

        public DateTime RevisionDate { get; set; }

        public string RevisionReason { get; set; }

        public string SpeciesGroup { get; set; }

        public string SpeciesGroupImageUrl { get; set; }

        public string SpeciesGroupInfoUrl { get; set; }
    }
}
