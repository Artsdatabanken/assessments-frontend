using Assessments.Frontend.Web.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Assessments.Frontend.Web.Controllers.Api
{
    [NotReadyForProduction]
    [ApiController, Produces("application/json")]
    public abstract class BaseApiController<T> : ControllerBase where T : BaseApiController<T>
    {
        private IWebHostEnvironment _environment;

        protected IWebHostEnvironment Environment => _environment ??= HttpContext.RequestServices.GetService<IWebHostEnvironment>();

        private DataRepository _dataRepository;

        protected DataRepository DataRepository => _dataRepository ??= HttpContext.RequestServices.GetService<DataRepository>();         
    }
}
