using System.ComponentModel.DataAnnotations;
using Assessments.Mapping.Models.Species;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2021ViewModel
    {
        public IPagedList<SpeciesAssessment2021> Redlist2021Results { get; set; }

        // Filter
        [Display(Name = "Navn"), FromQuery]
        public string Name { get; set; }
    }
}