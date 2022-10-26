using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Assessments.Frontend.Web.Infrastructure.Api
{
    public static class SwaggerSetup
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(
                    Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Constants.AssessmentsMappingAssembly}.xml"));
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Assessments api", Version = "v1", Description = "Species, alien species and naturetype assessments"
                    });
                var schemaHelper = new SwashbuckleSchemaHelper();
                options.CustomSchemaIds(type => schemaHelper.GetSchemaId(type));
            });
        }

        public static void Configure(WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Assessments api - Artsdatabanken";
                options.RoutePrefix = "swagger";
                options.SwaggerEndpoint("v1/swagger.json", "Assessments api");
                options.DefaultModelsExpandDepth(-1);
            });
        }
    }
}
