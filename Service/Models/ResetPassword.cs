using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Models
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "El email es un campo obligatorio")]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "El email debe tener entre 5 y 256 caracteres")]
        [EmailAddress]
        public String Email { get; set; }

        [Required(ErrorMessage = "El token es un obligatorio")]
        [RegularExpression("^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{4})$",
            ErrorMessage = "El formato del token no es valido")]
        public String Token { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo obligatorio")]
        public String Password { get; set; }

        [Required(ErrorMessage = "La confirmacion de contraseña es un campo obligatorio")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public String ConfirmPassword { get; set; }
    }
}
