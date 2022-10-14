using Assessments.Mapping.AlienSpecies;
using System;
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
        public AlienSpeciesListParameters()
        {
            this.Area = Array.Empty<string>();
            this.Category = Array.Empty<string>();
            this.Criterias = Array.Empty<string>();
            this.IsCheck = Array.Empty<string>();
            this.Meta = Array.Empty<string>();
            this.Regions = Array.Empty<string>();
            this.Habitats = Array.Empty<string>();
            this.SpeciesGroups = Array.Empty<string>();
            this.TaxonRank = Array.Empty<string>();
            this.WaterRegions = Array.Empty<string>();
        }

        public string[] Area { get; set; }

        public string[] Category { get; set; }

        public string[] Criterias { get; set; }

        public string[] Habitats { get; set; }

        public string[] IsCheck { get; set; }

        public string Name { get; set; }

        public string[] Meta { get; set; }

        public string[] Regions { get; set; }

        public string SortBy { get; set; }

        public string[] SpeciesGroups { get; set; }

        public string[] TaxonRank { get; set; }

        public string View { get; set; }

        public string[] WaterRegions { get; set; }
    }

    public class AlienSpeciesDetailViewModel
    {
        public AlienSpeciesAssessment2023 Assessment { get; set; }
    }
}
