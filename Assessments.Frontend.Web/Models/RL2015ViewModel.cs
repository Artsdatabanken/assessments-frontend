using System.ComponentModel.DataAnnotations;
using Artsdatabanken;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2015ViewModel
    {
        public IPagedList<Rodliste2015> Redlist2015Results { get; set; }

        // Filter
        [Display(Name = "Navn"), FromQuery(Name = "name")]
        public string Name { get; set; }

    }

}