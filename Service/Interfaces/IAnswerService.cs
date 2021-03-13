using Quicker.Interfaces.Service;
using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAnswerService : IOpenServiceAsync<int, Answer, AnswerDTO>
    {
        Task<IEnumerable<AnswerDTO>> GetTopVoted(int count);

        Task<IEnumerable<AnswerDTO>> GetBottomVoted(int count);
    }
}
