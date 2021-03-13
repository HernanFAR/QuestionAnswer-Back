using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Models
{
    public class ChangeInformation
    {
        [Required(ErrorMessage = "El correo original es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo original debe tener el formato apropiado")]
        public string OriginalEmail { get; set; }

        [Required(ErrorMessage = "El correo nuevo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo nuevo debe tener el formato apropiado")]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        public string IdEntity { get; set; }
    }
}
