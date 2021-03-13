using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Models
{
    public class RegisterData
    {
        [Required(ErrorMessage = "El email es un campo obligatorio")]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "El email debe tener entre 5 y 256 caracteres")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es un campo obligatorio")]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "El nombre de usuario debe tener entre 5 y 256 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo obligatorio")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmacion de contraseña es un campo obligatorio.")]
        [Compare("Password", ErrorMessage = "La confirmacion de contraseña no es igual a la ingresada.")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Debes ingresar un numero")]
        [Phone(ErrorMessage = "El numero debe ser valido")]
        public string PhoneNumber { get; set; }
    }
}

