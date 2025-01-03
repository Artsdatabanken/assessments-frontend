using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Assessments.Data;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Infrastructure.AlienSpecies;
using Assessments.Frontend.Web.Infrastructure.Api;
using Assessments.Frontend.Web.Infrastructure.Middleware;
using Assessments.Frontend.Web.Infrastructure.Services;
using Assessments.Shared.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .AddViewLocalization()
    .AddOData(ODataHelper.Options);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var cultures = new List<CultureInfo>
    {
        new("no"),
        new("en")
    };

    options.DefaultRequestCulture = new RequestCulture(cultures.First());

    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
    options.RequestCultureProviders.Remove(typeof(AcceptLanguageHeaderRequestCultureProvider));
});

builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();

builder.Services.AddDbContext<AssessmentsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException(), providerOptions => providerOptions.EnableRetryOnFailure());
});

builder.Host.UseNLog();

builder.Services.AddLazyCache();

builder.Services.AddSingleton<DataRepository>();

builder.Services.AddSingleton<AttachmentRepository>();

builder.Services.AddTransient<ExpertCommitteeMemberService>();

builder.Services.AddHttpClient<ArtsdatabankenApiService>();

builder.Services.AddHttpClient<ArtskartApiService>();

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(Constants.AssessmentsMappingAssembly));

builder.Services.AddSwagger(builder.Environment);

builder.Services.AddResponseCompression();

builder.Services.AddSendGrid(options => { options.ApiKey = builder.Configuration["SendGridApiKey"]; });

builder.Services.Configure<ApplicationOptions>(builder.Configuration.GetSection(nameof(ApplicationOptions)));

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddDataProtection().SetApplicationName("Assessments").PersistKeysToDbContext<AssessmentsDbContext>();
}
else
{
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    app.UseHsts();
}
else
{
    app.UseODataRouteDebug();
}

app.UseHttpsRedirection();

app.UseRequestLocalization();

app.UseRequestLocalizationCookies();

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

app.UseCookiePolicy(new CookiePolicyOptions
{
    Secure = CookieSecurePolicy.Always, 
    HttpOnly = HttpOnlyPolicy.Always, 
    MinimumSameSitePolicy = SameSiteMode.Strict
});

var cachedFilesFolder = Path.Combine(app.Environment.ContentRootPath, Constants.CacheFolder);

if (!Directory.Exists(cachedFilesFolder))
    Directory.CreateDirectory(cachedFilesFolder);

SwaggerSetup.Configure(app);

app.MapDefaultControllerRoute();

ExportHelper.Setup();

if (!app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<AssessmentsDbContext>();
    dataContext.Database.Migrate();
}

app.Run();