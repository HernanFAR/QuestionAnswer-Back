using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    public class QuestionAnswerUser : IdentityUser
    {
        [Display(Name = "Es administrador")]
        public bool IsAdmin { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<QuestionVote> QuestionVotes { get; set; }

        public ICollection<AnswerVote> AnswerVotes { get; set; }
    }
}
