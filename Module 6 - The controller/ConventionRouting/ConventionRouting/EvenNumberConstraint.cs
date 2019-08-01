using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ConventionRouting
{
    public class EvenNumberConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            int number;
            return int.TryParse(values[routeKey]?.ToString(), out number)
                   && number % 2 == 0;
        }
    }
}
