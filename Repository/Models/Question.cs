using Quicker.Abstracts.Model;
using Quicker.Interfaces.Model;
using Repository.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class Question : AbstractModel<int>, IDomainOf<QuestionDTO>
    {
        [Display(Name = "Pregunta"),
         Required(ErrorMessage = "La {0} es obligatoria."), 
         StringLength(150, MinimumLength = 5, ErrorMessage = "La {0} debe tener entre 5 y 150 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Categoria"),
         Range(1, int.MaxValue, ErrorMessage = "La {0} categoria debe ser valida.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Creador"),
         Required(ErrorMessage = "El {0} es obligatorio.")]
        public string QuestionAnswerUserId { get; set; }

        public QuestionAnswerUser QuestionAnswerUser { get; set; }

        [Display(Name = "Me gusta")]
        public int UpVotes { get; set; }

        [Display(Name = "No me gusta")]
        public int DownVotes { get; set; }

        [Display(Name = "Total de reacciones")]
        public int TotalVotes { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<QuestionVote> QuestionVotes { get; set; }
    }
}
