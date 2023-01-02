using System.IO;
using System.Linq;
using Assessments.Frontend.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assessments.Frontend.Web.Controllers
{
    public class FeedbackController : BaseController<FeedbackController>
    {
        [HttpPost]
        public IActionResult Index(FeedbackViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                TempData["feedback"] = returnUrl;
                
                // TODO: persist data

                string[] permittedExtensions = { ".pdf", ".doc", ".docx" };

                foreach (var formFile in viewModel.FormFiles)
                {
                    if (formFile.Length <= 0)
                        continue;

                    var extension = Path.GetExtension(formFile.FileName).ToLowerInvariant();

                    if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                        continue;

                    // TODO: persist file(s)
                }
            }

            return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : BadRequest();
        }
    }
}
