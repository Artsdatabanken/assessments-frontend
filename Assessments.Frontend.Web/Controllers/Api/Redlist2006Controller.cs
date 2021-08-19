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
    public class Species2006Controller : BaseController<Species2006Controller>
    {
        [HttpGet, EnableQuery(PageSize = 100)]
        [ProducesResponseType(typeof(IList<Redlist2006Assessment>), Status200OK)]
        public async Task<IActionResult> Get() => Ok(await DataRepository.GetData<Redlist2006Assessment>(Helpers.Constants.Species2006));

        [HttpGet, EnableQuery]
        [ProducesResponseType(typeof(Redlist2006Assessment), Status200OK), ProducesResponseType(Status404NotFound)]
        public async Task<IActionResult> Get(string key)
        {
            var data = await DataRepository.GetData<Redlist2006Assessment>(Helpers.Constants.Species2006);

            var result = data.Where(x => x.ArtsID == key);

            return Ok(SingleResult.Create(result.AsQueryable()));
        }
    }
}