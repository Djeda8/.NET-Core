using Binding.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binding.Controllers
{
    public class UserController1 : Controller
    {
        public IActionResult ChangePassword(UserData user)
        {
            if (!ModelState.IsValid)
            {
                return Content("Error getting friend");
            }
            return Content($"User name is {user.Username} and password is {user.Password}");
        }
    }
}
