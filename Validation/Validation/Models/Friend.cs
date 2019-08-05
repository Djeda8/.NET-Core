using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Validation.Models
{
    public class Friend
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(100), EmailAddress]
        public string Email { get; set; }

        [Range(18, 99)]
        public int Age { get; set; }

        public string Description { get; set; }
    }
}
