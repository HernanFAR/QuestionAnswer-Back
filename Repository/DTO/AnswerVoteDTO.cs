using Quicker.Abstracts.Model;
using Quicker.Interfaces.Model;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class AnswerVoteDTO : AbstractModel<int>, IDTOOf<AnswerVote>
    {
        public bool IsUpVote { get; set; }

        [Range(1, int.MaxValue)]
        public int AnswerId { get; set; }

        [Required]
        public string QuestionAnswerUserId { get; set; }

        public string QuestionAnswerUserName { get; set; }

        public string QuestionAnswerUserEmail { get; set; }
    }
}
