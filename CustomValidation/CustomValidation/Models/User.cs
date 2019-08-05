using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomValidation.Models
{
    public class User : IValidatableObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RetypedPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Username))
                yield return new ValidationResult(
                    "Username can't be empty",        // Mensaje de error
                    new[] { "Username" });            // Propiedad inválida

            if (Password != RetypedPassword)
                yield return new ValidationResult(
                    "Invalid password",                       // Mensaje de error
                    new[] { "Password", "RetypedPassword" }); // Propiedades inválidas


            // La siguiente validación no está asociada a una propiedad:
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                yield return new ValidationResult("We're closed on sundays");
        }
    }
}
