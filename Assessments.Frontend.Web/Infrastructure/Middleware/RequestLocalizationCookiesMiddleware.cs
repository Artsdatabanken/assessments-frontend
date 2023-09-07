﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace Assessments.Frontend.Web.Infrastructure.Middleware;

// husker valgt språk ved navigering til ulike sider

public class RequestLocalizationCookiesMiddleware : IMiddleware
{
    private CookieRequestCultureProvider Provider { get; }

    public RequestLocalizationCookiesMiddleware(IOptions<RequestLocalizationOptions> requestLocalizationOptions)
    {
        Provider = requestLocalizationOptions.Value.RequestCultureProviders.Where(x => x is CookieRequestCultureProvider).Cast<CookieRequestCultureProvider>().FirstOrDefault();
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (Provider != null)
        {
            var feature = context.Features.Get<IRequestCultureFeature>();

            if (feature != null)
            {
                context.Response.Cookies.Append(Provider.CookieName, CookieRequestCultureProvider.MakeCookieValue(feature.RequestCulture));
            }
        }

        await next(context);
    }
}