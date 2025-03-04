﻿using System;
using Assessments.Shared.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Assessments.Frontend.Web.Infrastructure
{
    /// <summary>
    /// Enable endpoint if not disabled in configuration
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class EnableAlienSpecies2023 : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var applicationOptions = context.HttpContext.RequestServices.GetService<IOptions<ApplicationOptions>>();

            if (!applicationOptions.Value.AlienSpecies2023.Enabled)
                context.Result = new NotFoundResult();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
