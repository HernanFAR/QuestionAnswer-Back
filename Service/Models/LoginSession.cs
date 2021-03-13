using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Models
{
    public class LoginSession
    {
        [Required(ErrorMessage = "El email es un campo obligatorio")]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "El email debe tener entre 5 y 256 caracteres")]
        [EmailAddress(ErrorMessage = "El email no tiene el formato correcto")]
        public String Email { get; set; }


        [Required(ErrorMessage = "La contraseña es un campo obligatorio")]
        public String Password { get; set; }
    }
}
