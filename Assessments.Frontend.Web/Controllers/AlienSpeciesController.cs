using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Assessments.Frontend.Web.Controllers
{
    [NotReadyForProduction]
    [Route("fremmedartslista/2023")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AlienSpeciesController : BaseController<AlienSpeciesController>
    {
        public async Task<IActionResult> Index(int? page, bool export)
        {
            var query = await DataRepository.GetAlienSpeciesAssessments();
            
            if (export)
            {
                var assessmentsForExport = Mapper.Map<IEnumerable<AlienSpeciesAssessment2023Export>>(query.ToList());
                return new FileStreamResult(ExportHelper.GenerateAlienSpeciesAssessment2023Export(assessmentsForExport, Request.GetDisplayUrl()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "fremmedartslista-2023.xlsx"
                };
            }

            var viewModel = new AlienSpeciesListViewModel
            {
                Results = query.ToPagedList(page ?? 1, DefaultPageSize)
            };

            return View("2023/Index", viewModel);
        }

        [Route("{id:required:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            var data = await DataRepository.GetAlienSpeciesAssessments();

            var assessment = data.FirstOrDefault(x => x.Id == id);

            if (assessment == null)
                return NotFound();

            return View("2023/Detail", assessment);
        }
    }
}
