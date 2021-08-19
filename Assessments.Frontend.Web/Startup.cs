using System.IO;
using Assessments.Frontend.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddControllersWithViews();

            services.AddTransient<AssessmentApiService>();

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            var applicationSettings = new ApplicationSettings();
            Configuration.GetSection(nameof(ApplicationSettings)).Bind(applicationSettings);

            services.AddLazyCache();
            
            services.AddSingleton<DataRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var cachedFilesFolder = Path.Combine(env.ContentRootPath, Helpers.Constants.CacheFolder);

            if (!Directory.Exists(cachedFilesFolder))
                Directory.CreateDirectory(cachedFilesFolder);
        }
    }
}
