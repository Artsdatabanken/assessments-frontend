using System;
using System.Threading.Tasks;
using Assessments.Shared.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Assessments.Frontend.Web.Infrastructure.Api;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyRequiredAttribute : Attribute, IAsyncActionFilter
{
    public const string ApiKeyHeader = "X-API-KEY";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeader, out var requestApiKey))
        {
            context.Result = new ObjectResult(new ProblemDetails
            {
                Title = $"{ApiKeyHeader} is required",
                Status = Status401Unauthorized
            });

            return;
        }

        var options = context.HttpContext.RequestServices.GetRequiredService<IOptions<ApplicationOptions>>();

        if (options.Value.SimpleApiKey == null)
            throw new Exception($"{nameof(ApplicationOptions.SimpleApiKey)} is not configured in application options");

        var simpleApiKey = options.Value.SimpleApiKey;

        if (!simpleApiKey.Equals(requestApiKey))
        {
            context.Result = new ObjectResult(new ProblemDetails
            {
                Title = $"{ApiKeyHeader} is invalid",
                Status = Status401Unauthorized
            });

            return;
        }

        await next();
    }
}