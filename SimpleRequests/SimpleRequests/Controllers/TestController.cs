using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRequests.Controllers
{
    public class TestController : Controller
    {
        // /{controller=home}/{action=index}/{id?}
        // /test/hello/John
        public IActionResult Hello(string id)
        {
            var name = id ?? "user";
            return Content($"Hello from ASP.NET Core MVC, {name}!");
        }

        // /{controller}/{action=index}/{id?}?age=int
        // /test/hello/peter?age=18
        //public IActionResult Hello(string id, int age)
        //{
        //    var name = id ?? "user";
        //    return Content($"Hello , {name}, you are {age} years old");
        //}

        // /{controller}
        // /test
        public IActionResult Index()
        {
            return Content($"Testing home");
        }
    }
}
