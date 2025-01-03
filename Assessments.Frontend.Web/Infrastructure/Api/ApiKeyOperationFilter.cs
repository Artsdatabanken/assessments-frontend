using System;
using System.Linq;
using Assessments.Shared.Options;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Assessments.Frontend.Web.Infrastructure.Api;

public class ApiKeyOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var controllerApiKeyRequired = context.MethodInfo.DeclaringType != null && context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<ApiKeyRequiredAttribute>().Any();

        var methodApiKeyRequired = context.MethodInfo.GetCustomAttributes(true).OfType<ApiKeyRequiredAttribute>().Any();

        var apiKeyRequired = !controllerApiKeyRequired && !methodApiKeyRequired;

        if (apiKeyRequired)
            return;

        operation.Responses.Add(Status401Unauthorized.ToString(), new OpenApiResponse { Description = ReasonPhrases.GetReasonPhrase(Status401Unauthorized) });

        operation.Security =
        [
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = nameof(ApplicationOptions.SimpleApiKey)
                        },
                        In = ParameterLocation.Header
                    },
                    Array.Empty<string>()
                }
            }
        ];
    }
}