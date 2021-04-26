using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class BrowserNameMiddleware
    {
        private RequestDelegate next;

        public BrowserNameMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext, IBrowserDetector detector)
        {
            var browser = detector.Browser;

            if (browser.Name == BrowserNames.Edge | browser.Name == BrowserNames.EdgeChromium 
                | browser.Name == BrowserNames.InternetExplorer)
            {
                await httpContext.Response.WriteAsync("Przegladarka nie jest obslugiwana");
            }
            else
            {
                await this.next.Invoke(httpContext);
            }
        }
    }
}
