using System.ComponentModel.DataAnnotations;
using Artsdatabanken;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Assessments.Frontend.Web.Models
{
    public class RL2021ViewModel
    {
        public IPagedList<RL2021> Redlist2021Results { get; set; }

        // Filter
        [Display(Name = "Navn"), FromQuery]
        public string Name { get; set; }

    }

}