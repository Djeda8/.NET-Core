using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binding.Models
{
    [BindRequired]
    public class Friend
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
