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
    public class QuestionVote : AbstractModel<int>, IDomainOf<QuestionVoteDTO>
    {
        public bool IsUpVote { get; set; }

        public int QuestionId { get; set; } 

        public Question Question { get; set; }

        [Required]
        public string QuestionAnswerUserId { get; set; }

        public QuestionAnswerUser QuestionAnswerUser { get; set; }

    }
}
