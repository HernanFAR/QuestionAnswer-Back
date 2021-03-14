using Quicker.Abstracts.Model;
using Quicker.Interfaces.Model;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.DTO
{
    public class AnswerDTO : AbstractModel<int>, IDTOOf<Answer>
    {
        [Display(Name = "Respuesta"),
         Required(ErrorMessage = "La {0} es obligatoria."),
         StringLength(150, MinimumLength = 5, ErrorMessage = "La {0} debe tener entre 5 y 150 caracteres.")]
        public string Name { get; set; }


        [Display(Name = "Pregunta"),
         Range(1, int.MaxValue, ErrorMessage = "La {0} es obligatoria.")]
        public int QuestionId { get; set; }

        public string Question { get; set; }

        [Display(Name = "Creador")]
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
