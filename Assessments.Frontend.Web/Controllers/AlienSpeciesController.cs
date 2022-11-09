using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Infrastructure.AlienSpecies;
using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies.Model;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Assessments.Frontend.Web.Controllers
{
    [NotReadyForProduction]
    [Route("fremmedartslista")]
    public class AlienSpeciesController : BaseController<AlienSpeciesController>
    {
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

            var viewModel = new AlienSpeciesDetailViewModel { Assessment = assessment };

            return View("2023/AlienSpeciesDetail", viewModel);
        }

        private IActionResult GetExport(IEnumerable<AlienSpeciesAssessment2023> query)
        {
            var assessmentsForExport = Mapper.Map<IEnumerable<AlienSpeciesAssessment2023Export>>(query.ToList());

            return new FileStreamResult(ExportHelper.GenerateAlienSpeciesAssessment2023Export(assessmentsForExport, Request.GetDisplayUrl()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "fremmedartslista-2023.xlsx"
            };
        }
    }
}
