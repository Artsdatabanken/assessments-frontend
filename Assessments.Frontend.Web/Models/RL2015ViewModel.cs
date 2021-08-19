using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2015ViewModel
    {
        public IPagedList<Mapping.Models.Species.Rodliste2015> Redlist2015Results { get; set; }

        // Filter
        [Display(Name = "Navn"), FromQuery]
        public string Name { get; set; }
    }
}