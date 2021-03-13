using Quicker.Abstracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class QuestionVote : AbstractModel<int>
    {
        public bool IsUp { get; set; }

        [Display(Name = "Pregunta"),
         Range(1, int.MaxValue, ErrorMessage = "La {0} es un obligatoria.")]
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public string QuestionAnswerUserId { get; set; }

        public QuestionAnswerUser QuestionAnswerUser { get; set; }

        [Required]
        public string VoterIp { get; set; }
    }
}
