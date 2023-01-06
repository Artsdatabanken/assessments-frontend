using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Assessments.Data;
using Assessments.Data.Models;
using Assessments.Frontend.Web.Models;
using Assessments.Shared.Helpers;
using Azure.Storage.Blobs;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Assessments.Frontend.Web.Controllers
{
    public class FeedbackController : BaseController<FeedbackController>
    {
        private readonly AssessmentsDbContext _dbContext;
        private readonly BlobContainerClient _blob;
        private readonly IConfiguration _configuration;

        public FeedbackController(IConfiguration configuration, AssessmentsDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _blob = new BlobContainerClient(configuration["ConnectionStrings:AzureBlobStorage"], "files");
        }

        public async Task<IActionResult> Index(string secret)
        {
            var feedbackSecret = _configuration["FeedbackSecret"];

            if (feedbackSecret != secret)
                return Unauthorized();

            var feedback = await _dbContext.Feedbacks.AsNoTracking().OrderBy(x => x.CreatedOn).ToListAsync();

            MemoryStream memoryStream;
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tilbakemeldinger");
                
                worksheet.Cell(1, 1).InsertTable(feedback);
                workbook.Worksheet(1).Columns().AdjustToContents();

                var worksheet2 = workbook.Worksheets.Add("Vedlegg");

                worksheet2.Cell(1, 1).Value = "FeedbackId";
                worksheet2.Cell(1, 2).Value = "Filnavn";

                var row = 1;

                var attachments = await _dbContext.FeedbackAttachments.AsNoTracking().ToListAsync();
                
                var baseUrl = $"{Request.Scheme}://{Request.Host.ToUriComponent()}{Request.PathBase.ToUriComponent()}";

                foreach (var attachment in attachments)
                {
                    ++row;

                    worksheet2.Cell(row, 1).Value = attachment.FeedbackId;
                    worksheet2.Cell(row, 2).Value = attachment.FileName;
                    worksheet2.Cell(row, 2).SetHyperlink(new XLHyperlink($"{baseUrl}/feedback/attachment/{attachment.Id}"));
                    worksheet2.Cell(row, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                }

                workbook.Worksheet(2).Columns().AdjustToContents();

                foreach (var workbookWorksheet in workbook.Worksheets)
                    workbookWorksheet.SheetView.FreezeRows(1);

                memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "feedback.xlsx"
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

        public async Task<IActionResult> Attachment(int id)
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
