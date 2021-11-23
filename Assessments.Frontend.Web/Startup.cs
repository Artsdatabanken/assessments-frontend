using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Assessments.Frontend.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllersWithViews().AddOData(options =>
            {
                options.AddRouteComponents("api", ODataModelConfiguration.EdmModel()).EnableQueryFeatures();
            });

            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Constants.AssessmentsMappingAssembly}.xml"));
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Assessments api", Version = "v1", Description = "Species, alien species and naturetype assessments" });
            });

            services.AddLazyCache();
            
            services.AddSingleton<DataRepository>();

            services.AddTransient<ExpertCommitteeMemberService>();

            services.AddHttpClient<ArtsdatabankenApiService>();
            services.AddHttpClient<ArtskartApiService>();

            services.AddAutoMapper(cfg => cfg.AddMaps(Constants.AssessmentsMappingAssembly));
            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseODataRouteDebug();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseStaticFiles(new StaticFileOptions {
                OnPrepareResponse = ctx =>
                {
                    // Cache static files for 30 days
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=86400");
                    ctx.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddDays(1).ToString("R", CultureInfo.InvariantCulture));
                }
            }); // cache static files

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseODataQueryRequest();

            if (env.IsDevelopment()) // ikke vis swagger (bortsett fra i utviklingsmiljø) #457 TODO: enable swagger at some point
            {
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = "swagger";
                    options.SwaggerEndpoint("v1/swagger.json", "Assessments api");
                    options.InjectJavascript("/js/swagger.js");
                });
            }

            var cachedFilesFolder = Path.Combine(env.ContentRootPath, Constants.CacheFolder);

            if (!Directory.Exists(cachedFilesFolder))
                Directory.CreateDirectory(cachedFilesFolder);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("nb-NO");
        }
    }
}
