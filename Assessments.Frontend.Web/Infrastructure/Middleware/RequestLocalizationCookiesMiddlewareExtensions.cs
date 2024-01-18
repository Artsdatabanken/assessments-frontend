using Microsoft.AspNetCore.Builder;

namespace Assessments.Frontend.Web.Infrastructure.Middleware
{
    public static class RequestLocalizationCookiesMiddlewareExtensions
    {
        public static void UseRequestLocalizationCookies(this IApplicationBuilder app) => app.UseMiddleware<RequestLocalizationCookiesMiddleware>();
    }
}