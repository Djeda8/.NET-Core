using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingSystem2
{
    public class EndsWithConstraint : IRouteConstraint
    {
        private readonly string _substr;
        public EndsWithConstraint(string substr)
        {
            _substr = substr.ToLower();
        }
        public bool Match(HttpContext httpContext, IRouter route, string parameterName,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            return values.ContainsKey(parameterName)
                   && values[parameterName].ToString().ToLower().EndsWith(_substr);
        }
    }
}
