using System.Collections.Generic;
using Artsdatabanken;

namespace Assessments.Frontend.Web.Models
{
    public class TestViewModel
    {
        public List<Rodliste2015> Redlist2015Results { get; set; } = new();

        public List<Redlist2006Assessment> Redlist2006Results { get; set; } = new();
    }
}