using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Mapping.Models.Species;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Assessments.Frontend.Web.Controllers.Api
{
    /// <summary>
    /// OData metoder som henter transformert datamodell (SpeciesAssessment2021) - Under utvikling
    /// </summary>
    public class Species2021Controller : BaseController<Species2021Controller>
    {
        [HttpGet, EnableQuery(PageSize = 100)]
        [ProducesResponseType(typeof(IList<SpeciesAssessment2021>), Status200OK)]
        public async Task<IActionResult> Get()
        {
            // var data = await DataRepository.GetData<SpeciesAssessment2021>(Constants.Filename.Species2021); // ferdig transformert modell
            var data = await DataRepository.GetMappedSpeciesAssessments(); // transformer modellen 

            return Ok(data);
        }

        [HttpGet, EnableQuery]
        [ProducesResponseType(typeof(SpeciesAssessment2021), Status200OK), ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Get(int key)
        {
            // var data = await DataRepository.GetData<SpeciesAssessment2021>(Constants.Filename.Species2021); // ferdig transformert modell
            var data = await DataRepository.GetMappedSpeciesAssessments(); // transformer modellen

            var result = data.Where(x => x.Id == key);

            return Ok(SingleResult.Create(result.AsQueryable()));
        }
    }
}