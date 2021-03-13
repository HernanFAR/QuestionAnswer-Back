using Quicker.Abstracts.Model;
using Quicker.Interfaces.Model;
using Repository.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Answer : AbstractModel<int>, IDomainOf<AnswerDTO>
    {
        [Display(Name = "Respuesta"),
         Required(ErrorMessage = "La {0} es obligatoria."),
         StringLength(150, MinimumLength = 5, ErrorMessage = "La {0} debe tener entre 5 y 150 caracteres.")]
        public string Name { get; set; }


        [Display(Name = "Pregunta"),
         Range(1, int.MaxValue, ErrorMessage = "La {0} es obligatoria.")]
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public string QuestionAnswerUserId { get; set; }

        public QuestionAnswerUser QuestionAnswerUser { get; set; }

        [Display(Name = "Votos")]
        public int Votes { get; set; }

        public ICollection<AnswerVote> AnswerVotes { get; set; }
    }
}
