using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class PasswordData
    {
        [Required(ErrorMessage = "El email es un campo obligatorio")]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "El email debe tener entre 5 y 256 caracteres")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo obligatorio")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmacion de contraseña es un campo obligatorio")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }
    }
}
