using System.Globalization;
using System.Text.Json.Serialization;
using Assessments.Data;
using Assessments.Web.Infrastructure;
using Assessments.Web.Infrastructure.AlienSpecies;
using Assessments.Web.Infrastructure.Middleware;
using Assessments.Web.Infrastructure.Services;
using Assessments.Shared.Options;
using Azure.Identity;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using RobotsTxt;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLog();

if (!builder.Environment.IsDevelopment())
{
    builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{builder.Configuration["KeyVault:Name"]}.vault.azure.net/"),
        new DefaultAzureCredential());

    builder.Services.AddApplicationInsightsTelemetry();
    builder.Services.AddSingleton<ITelemetryInitializer, TelemetryInitializer>();
}

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
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException(), providerOptions => providerOptions.MigrationsAssembly(typeof(AssessmentsDbContext).Assembly.FullName).EnableRetryOnFailure());
});

builder.Services.AddLazyCache();

builder.Services.AddSingleton<DataRepository>();

builder.Services.AddSingleton<AttachmentRepository>();

builder.Services.AddTransient<ExpertCommitteeMemberService>();

builder.Services.AddHttpClient<ArtsdatabankenApiService>();

builder.Services.AddHttpClient<ArtskartApiService>();

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(Constants.AssessmentsMappingAssembly));

builder.Services.AddResponseCompression(options => options.EnableForHttps = true);

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

if (!builder.Environment.IsProduction())
    builder.Services.AddStaticRobotsTxt(options => options.DenyAll());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseODataRouteDebug();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseResponseCompression();
}

app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseRequestLocalization();

app.UseRequestLocalizationCookies();

app.MapStaticAssets();

app.UseRobotsTxt();

app.UseCookiePolicy(new CookiePolicyOptions
{
    Secure = CookieSecurePolicy.Always, 
    HttpOnly = HttpOnlyPolicy.Always, 
    MinimumSameSitePolicy = SameSiteMode.Strict
});

var cachedFilesFolder = Path.Combine(app.Environment.ContentRootPath, Constants.CacheFolder);

if (!Directory.Exists(cachedFilesFolder))
    Directory.CreateDirectory(cachedFilesFolder);

app.MapDefaultControllerRoute().WithStaticAssets();

ExportHelper.Setup();

if (!app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<AssessmentsDbContext>();
    dataContext.Database.Migrate();
}

app.Run();