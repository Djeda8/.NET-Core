using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filters.Models;
using Microsoft.AspNetCore.Authorization;
using Filters.MiddlewaresFilters;

namespace Filters.Controllers
{
    //[Authorize]
    [Authorize(Roles = "admin, superadmin")]
    public class HomeController : Controller
    {
        //[Authorize]
        [AllowAnonymous]
        [MiddlewareFilter(typeof(ResponseCompressionPipeline))]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "CoolPeople")]
        //[Authorize("CoolPeople"]
        [Compress]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
