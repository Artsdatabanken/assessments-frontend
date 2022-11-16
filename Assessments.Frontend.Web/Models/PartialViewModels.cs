using Assessments.Mapping.AlienSpecies.Model.Enums;
using System;

namespace Assessments.Frontend.Web.Models
{
    public class AssessmentPageHeaderViewModel
    {
        public bool RenderSvalbard { get; set; }

        public ScientificNameViewModel scientificNameViewModel { get; set; }

        public SpeciesGroupViewModel speciesGroupViewModel { get; set; }
    }

    public class CitationForAssessmentViewModel
    {
        public string AssessmentName { get; set; }

        public int AssessmentYear { get; set; }

        public string ExpertCommittee { get; set; }

        public string FirstPublished { get; set; }

        public string CitationHeading { get; set; }

        public string PublicationText { get; set; }

        public DateTime RevisionDate { get; set; }

        public string RevisionReason { get; set; }

        public int YearPreviousAssessment { get; set; }
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
        public AlienSpeciesAssessment2023Category Category { get; set; }
        public string CriteriaDocumentation { get; set; }

        public string CriteriaDocumentationSpeciesStatus { get; set; }
        public string Summary { get; set; }
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
    }
}
