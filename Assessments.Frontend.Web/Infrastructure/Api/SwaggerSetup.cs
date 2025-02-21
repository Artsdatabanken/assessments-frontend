using System;
using System.IO;
using System.Reflection;
using Assessments.Shared.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Assessments.Frontend.Web.Infrastructure.Api;

public static class SwaggerSetup
{
    private const string Title = "Assessments API";

    public static void AddSwagger(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddSwaggerGen(options =>
        {
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);

            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = GetTitle(environment),
                    Version = "v1",
                    Description = "Species, alien species and naturetype assessments"
                });

            options.AddSecurityDefinition(nameof(ApplicationOptions.SimpleApiKey), new OpenApiSecurityScheme
            {
                Name = ApiKeyRequiredAttribute.ApiKeyHeader,
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<ApiKeyOperationFilter>();
        });
    }

    public static void Configure(WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.DocumentTitle = GetTitle(app.Environment);
            options.RoutePrefix = "swagger";
            options.SwaggerEndpoint("v1/swagger.json", "Assessments api");
            options.DefaultModelsExpandDepth(-1);
        });
    }

    private static string GetTitle(IWebHostEnvironment builderEnvironment)
    {
        var title = Title;

        if (!builderEnvironment.IsProduction())
            title = $"{title} - {builderEnvironment.EnvironmentName}";

        return title;
    }
}