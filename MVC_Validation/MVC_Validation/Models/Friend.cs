using MVC_Validation.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Validation.Models
{
    public class Friend : IValidatableObject
    {
        [Required, Contains("a", ErrorMessage = "{0} debe contener '{1}'")]
        public string Name { get; set; }
        [Range(18, 120)]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Address Address { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Address?.Street))
            {
                yield return new ValidationResult("Debe aparecer email o street", new[] { "email", "address.street" });
            }
            yield return ValidationResult.Success;
        }
    }
}
