
using System.ComponentModel.DataAnnotations;
using Artsdatabanken;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2006ViewModel
    {
        //public List<Redlist2006Assessment> Redlist2006Results { get; set; } = new();
        public IPagedList<Redlist2006Assessment> Redlist2006Results { get; set; }

        // Filter
        [Display(Name = "Navn"), FromQuery]
        public string Name { get; set; }
    }

}


