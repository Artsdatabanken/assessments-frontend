using System.Collections.Generic;
using Assessments.Mapping.Models.Species;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2021ViewModel
    {
        public IPagedList<SpeciesAssessment2021> Redlist2021Results { get; set; }
        
        public string Name { get; set; }
        public bool RE { get; set; }
        public bool CR { get; set; }
        public bool EN { get; set; }
        public bool VU { get; set; }
        public bool NT { get; set; }
        public bool DD { get; set; }
        public bool LC { get; set; }
        public bool NE { get; set; }
        public bool NA { get; set; }
        public bool CriteriaA { get; set; }
        public bool CriteriaB { get; set; }
        public bool CriteriaC { get; set; }
        public bool CriteriaD { get; set; }
        public bool Redlisted { get; set; }
        public bool Endangered { get; set; }
        public bool Norge { get; set; }
        public bool Svalbard { get; set; }
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
        public bool PresumedExtinct { get; set; }
        public string Redlist2021ResultsCount =>
            Redlist2021Results.Count > 0 ? 
                $"Viser {Redlist2021Results.Count} av {Redlist2021Results.TotalItemCount:N0}" : "Ingen resulater";

        public Species2001StatisticsViewModel Statistics { get; set; } = new();
    }

    public class Species2001StatisticsViewModel
    {
        public Dictionary<string, int> Categories { get; set; }

        public Dictionary<string, int> Criteria { get; set; }
    }
}