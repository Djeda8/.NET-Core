using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Validation.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        [Required, StringLength(5, MinimumLength = 5)]
        public string ZipCode { get; set; }
    }
}
