using System;
using System.Globalization;
using System.IO;
using System.Text.Json.Serialization;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Infrastructure.Api;
using Assessments.Frontend.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddLazyCache();

builder.Services.AddSingleton<DataRepository>();

builder.Services.AddTransient<ExpertCommitteeMemberService>();

builder.Services.AddHttpClient<ArtsdatabankenApiService>();

builder.Services.AddHttpClient<ArtskartApiService>();

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(Constants.AssessmentsMappingAssembly));

builder.Services.AddSwagger();

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

if (!app.Environment.IsProduction()) // Disable swagger in production
    SwaggerSetup.Configure(app);

app.MapDefaultControllerRoute();

ExportHelper.Setup();

app.Run();