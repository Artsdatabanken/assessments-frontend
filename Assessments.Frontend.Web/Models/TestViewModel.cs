using System.ComponentModel.DataAnnotations;
using Artsdatabanken;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class TestViewModel
    {
        public IPagedList<Rodliste2015> Redlist2015Results { get; set; }
        
        [Display(Name = "Navn"), FromQuery(Name = "name")]
        public string Name { get; set; }
    }
}