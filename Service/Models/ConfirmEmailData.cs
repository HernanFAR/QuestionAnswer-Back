using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Models
{
    public class ConfirmEmailData
    {
        [Required(ErrorMessage = "El identificador de usuario es un campo obligatorio")]
        public String UserId { get; set; }

        [Required(ErrorMessage = "El token de confirmacion de email es un campo obligatorio")]
        [RegularExpression("^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{4})$",
            ErrorMessage = "El formato del token no es valido")]
        public String Token { get; set; }
    }
}
