using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binding.Models
{
    public class UserData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        [BindNever]
        public bool? IsAdmin { get; set; }
    }
}
