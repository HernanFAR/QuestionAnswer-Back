using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Models
{
    public class ChangeUserNameData 
    {
        [Required(ErrorMessage = "El correo original es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo original debe tener el formato apropiado")]
        public string OriginalEmail { get; set; }

        [Required(ErrorMessage = "El nuevo nombre de usuario es obligatorio")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "El apodo debe tener entre 2 y 256 caracteres")]
        public string UserName { get; set; }

        public string IdEntity { get; set; }
    }
}
