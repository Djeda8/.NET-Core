using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.MiddlewaresFilters
{
    public class ResponseCompressionPipeline
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseResponseCompression();
        }
    }
}
