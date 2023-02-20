﻿using System;
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
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Assessments.Frontend.Web.Controllers
{
    public class FeedbackController : BaseController<FeedbackController>
    {
        private readonly AssessmentsDbContext _dbContext;
        private readonly BlobContainerClient _blob;
        private readonly string _feedbackSecret;
        private readonly ISendGridClient _sendGridClient;
        public const string ValidationCookieName = "FeedbackValidation";

        public FeedbackController(IConfiguration configuration, AssessmentsDbContext dbContext, ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
            _dbContext = dbContext;
            _blob = new BlobContainerClient(configuration["ConnectionStrings:AzureBlobStorage"], "feedback");
            _feedbackSecret = configuration["FeedbackSecret"];
        }

        public async Task<IActionResult> Index(string secret)
        {
            if (_feedbackSecret != secret)
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
                worksheet2.Cell(1, 2).Value = "ExpertGroup";
                worksheet2.Cell(1, 3).Value = "FileName";

                var row = 1;

                var attachments = await _dbContext.FeedbackAttachments.Include(x => x.Feedback).AsNoTracking().ToListAsync();
                
                var baseUrl = $"{Request.Scheme}://{Request.Host.ToUriComponent()}{Request.PathBase.ToUriComponent()}";

                foreach (var attachment in attachments)
                {
                    ++row;

                    worksheet2.Cell(row, 1).Value = attachment.FeedbackId;
                    worksheet2.Cell(row, 2).Value = attachment.Feedback.ExpertGroup;
                    worksheet2.Cell(row, 3).Value = attachment.FileName;
                    worksheet2.Cell(row, 3).SetHyperlink(new XLHyperlink($"{baseUrl}/feedback/attachment/{attachment.Id}?secret={_feedbackSecret}"));
                    worksheet2.Cell(row, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
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

        public async Task<IActionResult> Attachment(int id, string secret)
        {
            if (_feedbackSecret != secret)
                return Unauthorized();

            var attachment = await _dbContext.FeedbackAttachments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (attachment == null)
                return NotFound();

            var file = _blob.GetBlobClient(attachment.BlobName);

            if (!await file.ExistsAsync())
                return NotFound();

            var stream = await file.OpenReadAsync();

            return File(stream, "application/octet-stream", attachment.FileName);
        }

                public async Task<IActionResult> ValidateEmail(FeedbackFormViewModel viewModel, string returnUrl)
        {
            ModelState.Remove(nameof(FeedbackFormViewModel.Comment));

            if (!ModelState.IsValid || !Url.IsLocalUrl(returnUrl))
                return BadRequest("Beklager, en feil oppstod ved innsending av skjema.");

            var email = viewModel.Email.ToLowerInvariant();
            var emailValidation = await _dbContext.EmailValidations.FirstOrDefaultAsync(x => x.Email == email);

            if (emailValidation == null)
            {
                emailValidation = new EmailValidation
                {
                    Email = email,
                    FullName = viewModel.FullName.Trim()
                };

                _dbContext.EmailValidations.Add(emailValidation);
                
                await _dbContext.SaveChangesAsync();
            }

            var message = new SendGridMessage
            {
                From = new EmailAddress("noreply@artsdatabanken.no"),
                Subject = "Bekreftelse av e-postadresse for tilbakemelding"
            };

            message.AddTo(new EmailAddress(emailValidation.Email, emailValidation.FullName));
            
            var validationUrl = $"{Request.Scheme}://{Request.Host.ToUriComponent()}{returnUrl}?guid={emailValidation.Guid}#Feedback";
            
            var messageContent = $"<p>Klikk på lenken nedenfor for å bekrefte din e-postadresse. Dette gir deg tilgang til å gi tilbakemelding på Fremmedartsvurderinger i 2023.</p><p><a href='{validationUrl}'>{validationUrl}</a></p>";

            var sendMail = await SendMail(message, messageContent);

            if (!sendMail)
                return BadRequest("Beklager, en feil oppstod ved sending av e-post.");

            TempData["feedback"] = $"Du vil bli tilsendt en e-post (til {email}) som brukes for å bekrefte e-postadressen og med lenke for tilbakemelding.";

            return Url.IsLocalUrl(returnUrl) ? Redirect($"{returnUrl}#Feedback") : BadRequest();
        }

        public async Task<IActionResult> ForgetValidation(string code, string returnUrl)
        {
            if (!Guid.TryParse(code, out _) || !Url.IsLocalUrl(returnUrl))
                return BadRequest();

            var validation = await _dbContext.EmailValidations.FirstOrDefaultAsync(x => x.Guid == new Guid(code));

            if (validation == null)
                return BadRequest();

            _dbContext.EmailValidations.Remove(validation);

            await _dbContext.SaveChangesAsync();

            HttpContext.Response.Cookies.Delete(ValidationCookieName);

            TempData["feedback"] = "Din e-postadresse er slettet.";

            return Redirect($"{returnUrl.Split('?')[0]}#Feedback");
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback(FeedbackFormViewModel form, string code, string returnUrl)
        {
            if (!ModelState.IsValid || !Guid.TryParse(code, out _) || !Url.IsLocalUrl(returnUrl))
                return BadRequest();

            var validation = await _dbContext.EmailValidations.FirstOrDefaultAsync(x => x.Guid == new Guid(code));

            if (validation == null || !validation.Email.Equals(form.Email) || !validation.FullName.Equals(form.FullName))
                return BadRequest();

            var feedback = new Feedback
            {
                AssessmentId = form.AssessmentId,
                Year = form.Year,
                Type = form.Type,
                ExpertGroup = form.ExpertGroup,
                FullName = form.FullName.Trim().StripHtml(),
                Email = form.Email.ToLowerInvariant(),
                Comment = form.Comment.Trim().StripHtml()
            };

            _dbContext.Feedbacks.Add(feedback);

            await _dbContext.SaveChangesAsync();

            if (form.FormFiles != null)
            {
                await _blob.CreateIfNotExistsAsync();

                string[] permittedExtensions = { ".pdf", ".doc", ".docx", ".xls", ".xlsx" };

                foreach (var formFile in form.FormFiles)
                {
                    if (formFile.Length <= 0)
                        continue;

                    var extension = Path.GetExtension(formFile.FileName).ToLowerInvariant();

                    if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                        continue;

                    var encodedFileName = WebUtility.HtmlEncode(Path.GetFileName(formFile.FileName));
                    var blobName = $"{feedback.Type}/{feedback.Year}/{feedback.Id}/{Guid.NewGuid()}_{encodedFileName}";

                    await using var stream = formFile.OpenReadStream();
                    await _blob.UploadBlobAsync(blobName, stream);

                    feedback.Attachments.Add(new FeedbackAttachment
                    {
                        FeedbackId = feedback.Id,
                        BlobName = blobName,
                        FileName = formFile.FileName
                    });

                    Logger.LogDebug("{blobName} uploaded to storage", blobName);
                }

                await _dbContext.SaveChangesAsync();
            }

            var alienSpeciesAssessments = await DataRepository.GetAlienSpeciesAssessments();
            var assessment = alienSpeciesAssessments.FirstOrDefault(x => x.Id == feedback.AssessmentId);
            var scientificName = assessment != null ? assessment.ScientificName.ScientificName : string.Empty;

            var message = new SendGridMessage
            {
                From = new EmailAddress("noreply@artsdatabanken.no"),
                Subject = $"Tilbakemelding på foreløpig vurdering av {scientificName}"
            };

            message.AddTo(new EmailAddress(feedback.Email, feedback.FullName));

            var feedbackAttachments = string.Empty;

            if (feedback.Attachments.Any())
                feedbackAttachments = $"<p>Antall vedlegg: {feedback.Attachments.Count}</p>";

            var messageContent = $"<p>Under innsyn i de foreløpige vurderingene i Fremmedartslista 2023 har vi mottatt følgende tilbakemelding på vurderingen av {scientificName}:</p><p>{feedback.Comment}</p>{feedbackAttachments}";

            var sendMail = await SendMail(message, messageContent);

            if (!sendMail)
                return BadRequest("Beklager, en feil oppstod ved sending av e-post.");

            TempData["feedback"] = "Takk for tilbakemeldingen.";

            return Redirect($"{returnUrl}#Feedback");
        }

        public IActionResult Terms() => View();

        private async Task<bool> SendMail(SendGridMessage message, string messageContent)
        {
            messageContent += "<p>Dette er en automatisk generert e-post som du ikke kan svare på.</p>";

            message.AddContent(MimeType.Html, messageContent);
            message.AddContent(MimeType.Text, messageContent.StripHtml());

            try
            {
                var response = await _sendGridClient.SendEmailAsync(message);

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Failed sending email with StatusCode: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred: {message}", ex.Message);
                return false;
            }

            return true;
        }
    }
}
