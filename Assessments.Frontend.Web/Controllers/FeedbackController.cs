using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assessments.Frontend.Web.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Assessments.Frontend.Web.Controllers
{
    public class FeedbackController : BaseController<FeedbackController>
    {
        private readonly IConfiguration _configuration;

        public FeedbackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Index(FeedbackViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var folderId = Guid.NewGuid();

                if (viewModel.FormFiles.Any())
                {
                    var connectionString = _configuration["ConnectionStrings:AzureBlobStorage"];
                    var blob = new BlobContainerClient(connectionString, "files");

                    await blob.CreateIfNotExistsAsync();

                    string[] permittedExtensions = { ".pdf", ".doc", ".docx" };
                    
                    foreach (var formFile in viewModel.FormFiles.Where(x => x.Length <= 0))
                    {
                        var extension = Path.GetExtension(formFile.FileName).ToLowerInvariant();

                        if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                            continue;

                        await blob.UploadBlobAsync($"{folderId}/{formFile.FileName}", formFile.OpenReadStream());
                    }
                }

                // TODO: persist data

                TempData["feedback"] = "OK";

                return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : BadRequest();
            }

            return BadRequest("Beklager, en feil oppstod ved innsending av skjema");
        }
    }
}
