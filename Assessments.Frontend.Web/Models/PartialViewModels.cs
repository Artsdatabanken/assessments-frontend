using Assessments.Mapping.AlienSpecies;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class ControlButtonsViewModel
    {
        public string View { get; set; }

        public int ItemCount { get; set; }
    }

    public class CitationViewModel
    {
        public string CitationString { get; set; }
    }

    public class HeaderViewModel
    {
        public string Title { get; set; }
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

    public class SidebarContentViewModel
    {
        public string ScientificName { get; set; }

        public int ScientificNameId { get; set; }

        public string TaxonRank { get; set; }
    }
}
