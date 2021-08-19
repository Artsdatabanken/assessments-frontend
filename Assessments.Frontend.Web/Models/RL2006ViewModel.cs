using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2006ViewModel
    {
        public IPagedList<Mapping.Models.Species.Redlist2006Assessment> Redlist2006Results { get; set; }

        // Filter
        [Display(Name = "Navn"), FromQuery]
        public string Name { get; set; }
    }
}
