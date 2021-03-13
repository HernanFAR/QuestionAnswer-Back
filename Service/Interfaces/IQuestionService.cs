using Quicker.Interfaces.Service;
using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IQuestionService : IFullServiceAsync<int, Question, QuestionDTO>
    {
        Task<IEnumerable<QuestionDTO>> GetQuestionsWithCategory(int categoryId);

        Task<IEnumerable<QuestionDTO>> GetTopVoted(int count);

        Task<IEnumerable<QuestionDTO>> GetBottomVoted(int count);

        Task<IEnumerable<QuestionDTO>> GetOfUser(string identityId);
    }
}
