using System.Collections.Generic;
using Assessments.Mapping.Models.Species;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2021ViewModel
    {
        public IPagedList<SpeciesAssessment2021> Redlist2021Results { get; set; }
        
        public string Name { get; set; }

        public string Redlist2021ResultsCount =>
            Redlist2021Results.Count > 0 ? 
                $"Viser {Redlist2021Results.Count} av {Redlist2021Results.TotalItemCount:N0}" : "Ingen resulater";

        public Species2001StatisticsViewModel Statistics { get; set; } = new();
    }

    public class Species2001StatisticsViewModel
    {
        public IEnumerable<KeyValuePair<string, int>> Categories { get; set; }
    }
}