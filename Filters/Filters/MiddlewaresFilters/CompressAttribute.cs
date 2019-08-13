using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.MiddlewaresFilters
{
    public class CompressAttribute : MiddlewareFilterAttribute
    {
        public CompressAttribute() : base(typeof(ResponseCompressionPipeline)) { }
        public class ResponseCompressionPipeline
        {
            public void Configure(IApplicationBuilder app)
            {
                app.UseResponseCompression();
            }
        }
    }
}
