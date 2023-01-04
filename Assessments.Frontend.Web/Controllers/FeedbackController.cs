using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assessments.Data;
using Assessments.Data.Models;
using Assessments.Frontend.Web.Models;
using Assessments.Shared.Helpers;
using Azure.Storage.Blobs;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Assessments.Frontend.Web.Controllers
{
    public class FeedbackController : BaseController<FeedbackController>
    {
        private readonly AssessmentsDbContext _dbContext;
        private readonly BlobContainerClient _blob;

        public FeedbackController(IConfiguration configuration, AssessmentsDbContext dbContext)
        {
            _dbContext = dbContext;
            _blob = new BlobContainerClient(configuration["ConnectionStrings:AzureBlobStorage"], "files");
        }

        private static CsvConfiguration CsvConfiguration => new(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            Encoding = Encoding.UTF8
        };

        public async Task<IActionResult> Export()
        {
            var query = await _dbContext.Feedbacks.Include(x => x.Attachments).AsNoTracking().ToListAsync();

            byte[] result;
            await using (var memoryStream = new MemoryStream())
            await using (var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(true)))
            {
                var csvWriter = new CsvWriter(streamWriter, CsvConfiguration);

                await csvWriter.WriteRecordsAsync(query);
                await streamWriter.FlushAsync();
                result = memoryStream.ToArray();
            }

            return new FileStreamResult(new MemoryStream(result), "text/csv")
            {
                FileDownloadName = "feedback.csv"
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback(FeedbackFormViewModel formViewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Beklager, en feil oppstod ved innsending av skjema");
            
            var feedback = new Feedback
            {
                AssessmentId = formViewModel.AssessmentId,
                Year = formViewModel.Year,
                Type = formViewModel.Type,
                ExpertGroup = formViewModel.ExpertGroup,
                FullName = formViewModel.FullName.Trim().StripHtml(),
                Email = formViewModel.Email,
                Comment = formViewModel.Comment.Trim().StripHtml()
            };

            _dbContext.Feedbacks.Add(feedback);

            await _dbContext.SaveChangesAsync();
            
            var folderId = Guid.NewGuid();

            if (formViewModel.FormFiles != null)
            {
                await _blob.CreateIfNotExistsAsync();

                string[] permittedExtensions = { ".pdf", ".doc", ".docx" };

                foreach (var formFile in formViewModel.FormFiles)
                {
                    if (formFile.Length <= 0)
                        continue;

                    var extension = Path.GetExtension(formFile.FileName).ToLowerInvariant();

                    if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                        continue;

                    var encodedFileName = WebUtility.HtmlEncode(Path.GetFileName(formFile.FileName));
                    var blobName = $"{folderId}/{Guid.NewGuid()}_{encodedFileName}";

                    await using var stream = formFile.OpenReadStream();
                    await _blob.UploadBlobAsync(blobName, stream);

                    _dbContext.FeedbackAttachments.Add(new FeedbackAttachment
                    {
                        FeedbackId = feedback.Id, 
                        BlobName = blobName,
                        FileName = formFile.FileName
                    });
                }

                await _dbContext.SaveChangesAsync();
            }

            TempData["feedback"] = "OK";

            return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : BadRequest();
        }

        public async Task<IActionResult> GetAttachment(int id)
        {
            var attachment = await _dbContext.FeedbackAttachments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (attachment == null)
                return NotFound();

            var file = _blob.GetBlobClient(attachment.BlobName);
            
            if (!await file.ExistsAsync())
                return NotFound();

            var stream = await file.OpenReadAsync();

            return File(stream, "application/octet-stream", attachment.FileName);
        }
    }
}
