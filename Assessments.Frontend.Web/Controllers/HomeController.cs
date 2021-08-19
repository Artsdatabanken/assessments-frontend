using Microsoft.AspNetCore.Mvc;

namespace Assessments.Frontend.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
