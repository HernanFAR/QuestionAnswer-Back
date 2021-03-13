using Microsoft.AspNetCore.Mvc;
using Quicker.Interfaces.WebApiController;
using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionAnswer.Interface
{
    public interface IQuestionController : IFullControllerAsync<int, Question, QuestionDTO>
    {
        Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestionsWithCategory(int categoryId);

        Task<ActionResult<IEnumerable<QuestionDTO>>> GetTopVoted(int count);

        Task<ActionResult<IEnumerable<QuestionDTO>>> GetBottomVoted(int count);

        Task<ActionResult<IEnumerable<QuestionDTO>>> GetOfUser(string identityId);
    }
}
