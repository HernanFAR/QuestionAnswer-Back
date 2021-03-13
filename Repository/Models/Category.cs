using Quicker.Abstracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class Category : AbstractModel<int>
    {
        [Display(Name = "Categoria"), 
         Required(ErrorMessage = "La {0} es un dato obligatorio"), 
         StringLength(25, MinimumLength = 2, ErrorMessage = "La {0} debe tener entre 25 y 2 caracteres.")]
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
