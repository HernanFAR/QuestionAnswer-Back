using Quicker.Abstracts.Model;
using Quicker.Interfaces.Model;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.DTO
{
    public class QuestionDTO : AbstractModel<int>, IDTOOf<Question>
    {
        [Display(Name = "Pregunta"),
         Required(ErrorMessage = "La {0} es obligatoria."),
         StringLength(150, MinimumLength = 5, ErrorMessage = "La {0} debe tener entre 5 y 150 caracteres,")]
        public string Name { get; set; }

        [Display(Name = "Categoria"),
         Range(1, int.MaxValue, ErrorMessage = "La {0} categoria debe ser un campo valido")]
        public int CategoryId { get; set; }

        public string Category { get; set; }

        [Display(Name = "Creador"),
         Required(ErrorMessage = "El {0} es un campo obligatorio")]
        public string QuestionAnswerUserId { get; set; }

        public string QuestionAnswerUserName { get; set; }

        public string QuestionAnswerUserEmail { get; set; }

        [Display(Name = "Me gusta")]
        public int UpVotes { get; set; }

        [Display(Name = "No me gusta")]
        public int DownVotes { get; set; }

        [Display(Name = "Total de reacciones")]
        public int TotalVotes { get; set; }
    }
}
