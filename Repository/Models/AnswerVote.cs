using Quicker.Abstracts.Model;
using Quicker.Interfaces.Model;
using Repository.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class AnswerVote : AbstractModel<int>, IDomainOf<AnswerVoteDTO>
    {
        public bool IsUpVote { get; set; }

        public int AnswerId { get; set; }

        public Answer Answer { get; set; }

        [Required]
        public string QuestionAnswerUserId { get; set; }

        public QuestionAnswerUser QuestionAnswerUser { get; set; }
    }
}
