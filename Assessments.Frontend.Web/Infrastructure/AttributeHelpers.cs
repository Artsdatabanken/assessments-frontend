using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Assessments.Frontend.Web.Infrastructure
{
    /// <summary>
    /// Disables endpoint in production environment
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class NotReadyForProduction : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var environment = context.HttpContext.RequestServices.GetService<IWebHostEnvironment>();

            if (!environment.IsDevelopment())
                context.Result = new NotFoundResult();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
