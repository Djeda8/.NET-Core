using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Middlewares
{
    public static class CalculatorExtensions
    {
        public static IApplicationBuilder UseCalculator(this IApplicationBuilder app,
                                                        string path)
        {
            return app.UseMiddleware<CalculatorMiddleware>(path);
        }
    }
}
