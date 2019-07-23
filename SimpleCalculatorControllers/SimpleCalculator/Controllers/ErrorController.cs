using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger _logger;

        public ErrorController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ErrorController>();

        }
        public IActionResult Show(int id)
        {
            var html = string.Empty;
            if (id == 500)
            {
                var exceptionHandlerFeature =
                        HttpContext.Features.Get<IExceptionHandlerFeature>();
                var exception = exceptionHandlerFeature.Error;
                var exceptionName = exception.GetType().Name;
                _logger.LogError($"Exception thrown '{exceptionName}: {exception.Message}'");
                html = SendHtmlPage(
                    statusCode: 500,
                    title: $"Server error",
                    description: $"We have detected a server error {exceptionName}"
                ); // Obtener HTML de la página de error para el código 500.
            }
            else if (id == 404)
            {
                var statusCodeFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                var path = statusCodeFeature.OriginalPath;
                _logger.LogError($"Error 404 for path '{path}'");
                html = SendHtmlPage(
                    statusCode: 404,
                    title: "Not found",
                    description: $"No content found at '{path}'"
                ); // Obtener HTML de la página de error para el código 404.
            }
            return Content(html, contentType: "text/html");
        }
        private string SendHtmlPage(int statusCode, string title, string description)
        {
            var content = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8' />
                    <title>{title}</title>
                    <link href='/styles/site.css' rel='stylesheet' />
                </head>
                <body>
                    <h1>
                        <span class='statusCode'>{statusCode}</span> {title}
                    </h1>
                    <p>{description}.</p>
                    <p><a href='javascript:history.back()'>Go back</a>.</p>
                </body>
                </html>
        ";
            return content;
        }
    }
}
