using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingSystem2.Controllers
{
    [Route("[controller]")]
    public class FriendsController : Controller
    {
        // Ruta: /Friends/
        public IActionResult Index()
        {
            var message = "FriendsController.Index()";
            return Content(message);
        }

        // Ruta: /Friends/View/John
        [Route("View/{name:StartsWith(jo)}")]
        public IActionResult View(string name)
        {
            var message = string.Format("FriendsController.View('{0}')", name);
            return Content(message);
        }

        // Ruta: /Friends/Edit/23
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var message = string.Format("FriendsController.Edit({0})", id);
            return Content(message);
        }
        // Ruta: /Delete/Friends/18
        [Route("/Delete/Friends/{id:range(1,99999998)}")]
        public IActionResult Delete(int id)
        {
            var message = string.Format("FriendsController.Delete({0})", id);
            return Content(message);
        }
    }
}
