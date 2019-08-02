using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingSystem2
{
    public class StartsWithConstraint : IRouteConstraint
    {
        private readonly string _substr;
        public StartsWithConstraint(string substr)
        {
            _substr = substr;
        }
        public bool Match(HttpContext httpContext, IRouter route, string parameterName,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            return values.ContainsKey(parameterName)
                   && values[parameterName].ToString().StartsWith(_substr);
        }
    }
}
