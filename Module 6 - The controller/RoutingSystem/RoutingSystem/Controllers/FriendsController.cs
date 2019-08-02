using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingSystem.Controllers
{
    public class FriendsController : Controller
    {
        // Ruta: /Friends/
        public IActionResult Index()
        {
            var message = "FriendsController.Index()";
            return Content(message);
        }

        // Ruta: /Friends/View/John
        public new IActionResult View(string name)
        {
            var message = string.Format("FriendsController.View('{0}')", name);
            return Content(message);
        }

        // Ruta: /Friends/Edit/23
        public IActionResult Edit(int id)
        {
            var message = string.Format("FriendsController.Edit({0})", id);
            return Content(message);
        }
        // Ruta: /Delete/Friends/18
        public IActionResult Delete(int id)
        {
            var message = string.Format("FriendsController.Delete({0})", id);
            return Content(message);
        }
    }
}
