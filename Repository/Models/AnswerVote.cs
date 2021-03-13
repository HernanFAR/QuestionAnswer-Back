using Quicker.Abstracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class AnswerVote : AbstractModel<int>
    {
        public bool IsUp { get; set; }

        [Display(Name = "Respuesta"),
         Range(1, int.MaxValue, ErrorMessage = "La {0} es un obligatoria.")]
        public int AnswerId { get; set; }

        public Answer Answer { get; set; }

        public string QuestionAnswerUserId { get; set; }

        public QuestionAnswerUser QuestionAnswerUser { get; set; }

        [Required]
        public string VoterIp { get; set; }
    }
}
