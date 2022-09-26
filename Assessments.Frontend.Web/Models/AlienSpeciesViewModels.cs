using Assessments.Mapping.Models.AlienSpecies;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class AlienSpeciesListViewModel
    {
        public IPagedList<AlienSpeciesAssessment2023> Results { get; set; }
    }
}
