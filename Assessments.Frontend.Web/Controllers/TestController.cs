using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Default;

namespace Assessments.Frontend.Web.Controllers
{
    public class TestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // TODO: move service url(s) to appsettings
            var context = new Container(new Uri("https://assessmentsapi.test.artsdatabanken.no/api/"));
            
            var redlistResults = await context.Redlist.ExecuteAsync();

            return View(redlistResults.ToList());
        }
    }
}
