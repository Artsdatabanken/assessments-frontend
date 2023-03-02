using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Infrastructure.AlienSpecies;
using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Shared.Helpers;
using Assessments.Shared.Options;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Assessments.Frontend.Web.Controllers
{
    [EnableAlienSpecies2023]
    [Route("fremmedartslista")]
    public class AlienSpeciesController : BaseController<AlienSpeciesController>
    {
        private readonly AttachmentRepository _attachmentRepository;
        private readonly AlienSpecies2023Options _alienSpecies2023Options;

        public AlienSpeciesController(IOptions<ApplicationOptions> options, AttachmentRepository attachmentRepository)
        {
            _alienSpecies2023Options = options.Value.AlienSpecies2023;
            _attachmentRepository = attachmentRepository;
        }

        public IActionResult Home() => View("AlienSpeciesHome");

        [Route("2023")]
        public async Task<IActionResult> Index(AlienSpeciesListViewModel viewModel, int? page, bool export)
        {
            var query = await DataRepository.GetAlienSpeciesAssessments();

            query = QueryHelpers.ApplyParameters(viewModel, query);

            if (export)
                return GetExport(query);

            viewModel.Results = query.ToPagedList(page ?? 1, DefaultPageSize);

            return View("2023/AlienSpeciesIndex", viewModel);
        }

        [Route("2023/{id:required:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            var data = await DataRepository.GetAlienSpeciesAssessments();

            var assessment = data.FirstOrDefault(x => x.Id == id);

            if (assessment == null)
                return NotFound();

            var expertGroupMembers = await DataRepository.GetData<AlienSpeciesAssessment2023ExpertGroupMember>(DataFilenames.AlienSpeciesExpertCommitteeMembers);

            var assessmentExpertGroupMembers = await expertGroupMembers.Where(x => x.ExpertGroup == assessment.ExpertGroup)
                .OrderBy(x => x.ExpertGroup)
                .ThenBy(x => new List<string> { "Leder", "Medlem" }.IndexOf(x.ExpertGroupRole)).ThenBy(x => x.LastName).ToListAsync();

            var viewModel = new AlienSpeciesDetailViewModel(assessment)
            {
                ExpertGroupMembers = assessmentExpertGroupMembers
            };

            return View("2023/AlienSpeciesDetail", viewModel);
        }

        [Route("2023/Attachment/{attachmentId:required:int}")]
        public async Task<IActionResult> Attachment(int attachmentId)
        {
            var data = await DataRepository.GetAlienSpeciesAssessments();
            var assessment = data.FirstOrDefault(x => x.Attachments.Any(y => y.Id == attachmentId));

            if (assessment == null)
                return NotFound();

            var attachment = assessment.Attachments.Single(x => x.Id == attachmentId);

            var stream = await _attachmentRepository.GetFileStream(DataFilenames.CalculateAlienSpecies2023AttachmentFilePath(attachmentId, attachment.FileName));

            if (stream == null)
                return NotFound();

            return new FileStreamResult(stream, attachment.MimeType)
            {
                FileDownloadName = attachment.FileName
            };
        }

        private IActionResult GetExport(IEnumerable<AlienSpeciesAssessment2023> query)
        {
            if (_alienSpecies2023Options.IsHearing)
                return NotFound();

            var assessmentsForExport = Mapper.Map<IEnumerable<AlienSpeciesAssessment2023Export>>(query.ToList());

            return new FileStreamResult(ExportHelper.GenerateAlienSpeciesAssessment2023Export(assessmentsForExport, Request.GetDisplayUrl()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "fremmedartslista-2023.xlsx"
            };
        }
    }
}
