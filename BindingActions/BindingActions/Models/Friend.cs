using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BindingActions.Models
{
    public class Friend
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Address Address {get; set;}
    }
}
