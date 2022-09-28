using Assessments.Mapping.Models.AlienSpecies;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class AlienSpeciesListViewModel
    {
        public IPagedList<AlienSpeciesAssessment2023> Results { get; set; }
        
        public AlienSpeciesListParameters Parameters { get; set; } = new();
    }

    public class AlienSpeciesListParameters
    {
        public string Name { get; set; }
    }

    public class AlienSpeciesDetailViewModel
    {
        public AlienSpeciesAssessment2023 Assessment { get; set; }
    }
}
