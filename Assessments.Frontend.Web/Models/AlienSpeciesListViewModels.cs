using Assessments.Mapping.AlienSpecies.Model;
using System;
using System.Collections.Generic;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class AlienSpeciesListViewModel : AlienSpeciesListParameters
    {
        public IPagedList<AlienSpeciesAssessment2023> Results { get; set; }

        public AlienSpeciesStatistics2023 Statistics { get; set; }
    }

    public class AlienSpeciesListParameters
    {
        public IEnumerable<string> FilterParameters { get; } = new[]
        {
            nameof(Area), nameof(Category),  nameof(Criterias), nameof(SpeciesStatus), nameof(Habitats), nameof(ProductionSpecies), nameof(Regions), nameof(SpeciesGroups), nameof(TaxonRank), nameof(WaterRegions), nameof(CategoryChanged)
        };

        public string SortBy { get; set; }

        public string View { get; set; }

        public string[] Meta { get; set; } = Array.Empty<string>();

        public string[] IsCheck { get; set; } = Array.Empty<string>();

        public string Name { get; set; }

        public string[] Area { get; set; } = Array.Empty<string>();

        public string[] Category { get; set; } = Array.Empty<string>();

        public string[] CategoryChanged { get; set; } = Array.Empty<string>();

        public string[] Criterias { get; set; } = Array.Empty<string>();

        public string[] SpeciesStatus { get; set; } = Array.Empty<string>();

        public string[] Habitats { get; set; } = Array.Empty<string>();

        public string[] ProductionSpecies { get; set; } = Array.Empty<string>();

        public string[] Regions { get; set; } = Array.Empty<string>();

        public string[] SpeciesGroups { get; set; } = Array.Empty<string>();

        public string[] TaxonRank { get; set; } = Array.Empty<string>();

        public string[] WaterRegions { get; set; } = Array.Empty<string>();
    }

    public class AlienSpeciesStatistics2023
    {
        // These are temporary and taken from redlist2021. Alien species might need other statistics
        public Dictionary<string, int> Categories { get; set; }

        public Dictionary<string, int> Criteria { get; set; }

        public Dictionary<string, int> Habitat { get; set; }

        public Dictionary<string, int> ImpactFactors { get; set; }

        public Dictionary<string, int> Region { get; set; }

        public List<string> RegionNames { get; set; }
    }
}
