using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Infrastructure.Api;
using Assessments.Frontend.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });

builder.Services.AddControllersWithViews();

builder.Services.AddLazyCache();

builder.Services.AddSingleton<DataRepository>();

builder.Services.AddTransient<ExpertCommitteeMemberService>();

builder.Services.AddHttpClient<ArtsdatabankenApiService>();

builder.Services.AddHttpClient<ArtskartApiService>();

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(Constants.AssessmentsMappingAssembly));

builder.Services.AddSwaggerGen(options =>
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

builder.Services.AddResponseCompression();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseResponseCompression();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Cache static files for 30 days
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=86400");
        ctx.Context.Response.Headers.Append("Expires",
            DateTime.UtcNow.AddDays(1).ToString("R", CultureInfo.InvariantCulture));
    }
});

var cachedFilesFolder = Path.Combine(app.Environment.ContentRootPath, Constants.CacheFolder);

if (!Directory.Exists(cachedFilesFolder))
    Directory.CreateDirectory(cachedFilesFolder);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("nb-NO");

if (app.Environment.IsDevelopment()) // Enables swagger in development
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

app.MapDefaultControllerRoute();

app.Run();