using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingAuthentication
{
    public static class PageUtils
    {
        public static async Task SendPageAsync(HttpContext context, string title, string body)
        {
            var content = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8' />
                <title>{title}</title>
                <link href='../styles/site.css' rel='stylesheet' />
            </head>
            <body>
                {body}
            </body>
            </html>
        ";
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(content);
        }
    }
}
