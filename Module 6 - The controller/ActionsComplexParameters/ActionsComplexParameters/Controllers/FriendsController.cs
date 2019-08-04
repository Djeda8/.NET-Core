using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionsComplexParameters.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionsComplexParameters.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult Show(Friend friend)
        {
            return Content($"{friend.Name} is {friend.Age} years old "
                + $"and lives in {friend.Address.Street} ({friend.Address.ZipCode})");
        }
    }
}