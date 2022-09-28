using Assessments.Frontend.Web.Infrastructure.Api;
using Assessments.Mapping.Models.Species;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Assessments.Frontend.Web.Controllers.Api
{
    [Route("api/[controller]/2021")]
    public class SpeciesController : BaseApiController<SpeciesController>
    {
        [HttpGet, ProducesResponseType(typeof(PaginatedResults<List<SpeciesAssessment2021>>), Status200OK)]
        public async Task<ActionResult> GetSpecies2021(int pageNumber = 1, int pageSize = 25)
        {
            var query = await DataRepository.GetSpeciesAssessments();

            var total = query.Count();
            var skip = (pageNumber - 1) * pageSize;
            var data = query.Skip(skip).Take(pageSize).ToList();

            return Ok(new PaginatedResults<SpeciesAssessment2021>(data, pageNumber, pageSize, total));
        }

        [HttpGet("{id:int:required}"), ProducesResponseType(typeof(SpeciesAssessment2021), Status200OK)]
        public async Task<ActionResult> GetAlienSpecies2023ById(int id)
        {
            var query = await DataRepository.GetSpeciesAssessments();

            var assessment = query.FirstOrDefault(x => x.Id == id);

            if (assessment == null)
                return NotFound();

            return Ok(assessment);
        }
    }
}
