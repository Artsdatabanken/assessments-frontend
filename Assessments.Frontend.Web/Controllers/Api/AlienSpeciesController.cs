using Assessments.Frontend.Web.Infrastructure.Api;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessments.Frontend.Web.Infrastructure.AlienSpecies;
using Assessments.Frontend.Web.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Frontend.Web.Controllers.Api
{
    [Route("api/[controller]/2023")]
    public class AlienSpeciesController : BaseApiController<AlienSpeciesController>
    {
        [HttpGet, ProducesResponseType(typeof(PaginatedResults<List<AlienSpeciesAssessment2023>>), Status200OK)]
        public async Task<ActionResult> GetAlienSpecies2023(string name, [FromQuery] AlienSpeciesAssessment2023Category[] category, int pageNumber = 1, int pageSize = 25)
        {
            var query = await DataRepository.GetAlienSpeciesAssessments();

            var parameters = new AlienSpeciesListParameters
            {
                Name = name, 
                Category = category.Select(x => x.ToString()).ToArray()
            };

            query = QueryHelpers.ApplyParameters(parameters, query);

            var total = query.Count();
            var skip = (pageNumber - 1) * pageSize;
            var data = query.Skip(skip).Take(pageSize).ToList();

            return Ok(new PaginatedResults<AlienSpeciesAssessment2023>(data, pageNumber, pageSize, total));
        }

        [HttpGet("{id:int:required}"), ProducesResponseType(typeof(AlienSpeciesAssessment2023), Status200OK)]
        public async Task<ActionResult> GetAlienSpecies2023ById(int id)
        {
            var query = await DataRepository.GetAlienSpeciesAssessments();

            var assessment = query.FirstOrDefault(x => x.Id == id);

            if (assessment == null)
                return NotFound();

            return Ok(assessment);
        }
    }
}
