using System;
using System.Collections.Generic;
using Assessments.Mapping.Models.Species;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2021ViewModel
    {
        public RL2021ViewModel()
        {
            this.Criterias = new FilterCriterias();
            this.Regions = new FilterRegions();
            this.Area = Array.Empty<string>();
            this.IsCheck = Array.Empty<string>();
            this.Region = Array.Empty<string>();
            this.Category = Array.Empty<string>();
        }
        public IPagedList<SpeciesAssessment2021> Redlist2021Results { get; set; }
        public string[] Area { get; set; }
        public string[] Region { get; set; }
        public string Name { get; set; }
        public bool Redlisted { get; set; }
        public bool Endangered { get; set; }
        public bool PresumedExtinct { get; set; }
        public FilterCriterias Criterias { get; set; }
        public FilterRegions Regions { get; set; }
        public bool EuropeanPopLt5 { get; set; }
        public bool EuropeanPopRange5To25 { get; set; }
        public bool EuropeanPopRange25To50 { get; set; }
        public bool EuropeanPopGt50 { get; set; }
        public string[] IsCheck { get; set; }
        
        public string Redlist2021ResultsCount =>
            Redlist2021Results.Count > 0 ? 
                $"Viser {Redlist2021Results.Count} av {Redlist2021Results.TotalItemCount:N0}" : "Ingen resulater";

        public Species2001StatisticsViewModel Statistics { get; set; } = new();
        public string[] Category { get; set; }
    }

    public class FilterCriterias
    {
        public bool CriteriaA { get; set; }
        public bool CriteriaB { get; set; }
        public bool CriteriaC { get; set; }
        public bool CriteriaD { get; set; }
    } 

    public class FilterRegions
    {
        public bool Agder { get; set; }
        public bool Innlandet { get; set; }
        public bool VestFoldTelemark { get; set; }
        public bool MoreRomsdal { get; set; }
        public bool Nordland { get; set; }
        public bool Rogaland { get; set; }
        public bool TromsFinnmark { get; set; }
        public bool Trondelag { get; set; }
        public bool Vestland { get; set; }
        public bool VikenOslo { get; set; }
        public bool Havomroder { get; set; }
    }

    public class Species2001StatisticsViewModel
    {
        public Dictionary<string, int> Categories { get; set; }

        public Dictionary<string, int> Criteria { get; set; }

        public Dictionary<string, int> Habitat { get; set; }

        public Dictionary<string, int> Region { get; set; }

        public List<string> RegionNames { get; set; }
    }
}