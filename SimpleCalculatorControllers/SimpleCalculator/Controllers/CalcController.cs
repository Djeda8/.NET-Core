using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleCalculator.Services;

namespace SimpleCalculator.Controllers
{
    public class CalcController : Controller
    {
        private readonly ICalculatorServices _calculatorServices;
        private readonly ILogger _logger;
        private const string BasePath = "/calc";

        public CalcController(ILoggerFactory loggerFactory, ICalculatorServices calculatorServices)
        {
            _logger = loggerFactory.CreateLogger<CalcController>();
            _calculatorServices = calculatorServices;
        }
        public IActionResult Index()
        {
            var html = SendHtmlPage(
                "Start",
                $@" <form method='post' action='{BasePath}/results'>
                <input type='number' name='a'>
                <select name='operation'>
                    <option value='+'>+</option>
                    <option value='-'>-</option>
                    <option value='*'>*</option>
                    <option value='/'>/</option>
                </select>
                <input type='number' name='b'>
                <input type='submit' value='Calculate'>
            </form>
        ");
             return Content(html, contentType: "text/html");
        }

        public IActionResult Results(int a, int b, string operation)
        {
            var result = _calculatorServices.Calculate(a, b, operation);
            var html = SendHtmlPage(
                "Results",
                $@"<h2>{a}{operation}{b}={result}</h2>
            <p><a href='{BasePath}'>Back</a></p>"
            );

            return Content(html, contentType: "text/html");
        }


        private string SendHtmlPage( string title, string body)
        {
            var content = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset='utf-8' />
            <title>{title} - Calculator</title>
            <link href='/styles/site.css' rel='stylesheet' />
        </head>
        <body>
            <h1>
                <img src='/images/calculator.png' height='35' />
                Simple calculator
            </h1>
            {body}
        </body>
        </html>
            ";
            return content;
        }
    }
}