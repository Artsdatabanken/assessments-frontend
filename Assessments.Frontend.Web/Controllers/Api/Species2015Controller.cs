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
    /// OData enabled
    /// </summary>
    public class Species2015Controller : BaseController<Species2015Controller>
    {
        [HttpGet, EnableQuery(PageSize = 100)]
        [ProducesResponseType(typeof(IList<Rodliste2015>), Status200OK)]
        public async Task<IActionResult> Get() => Ok(await DataRepository.GetData<Rodliste2015>(Constants.Filename.Species2015));

        [HttpGet, EnableQuery]
        [ProducesResponseType(typeof(Rodliste2015), Status200OK), ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Get(int keyLatinsknavnId, string keyVurderingsContext)
        {
            var data = await DataRepository.GetData<Rodliste2015>(Constants.Filename.Species2015);

            var result = data.Where(x => x.LatinsknavnId == keyLatinsknavnId && x.VurderingsContext == keyVurderingsContext);

            return Ok(SingleResult.Create(result.AsQueryable()));
        }
    }
}