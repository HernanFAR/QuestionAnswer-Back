using Quicker.Interfaces.Service;
using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAnswerService : ICloseServiceAsync<int, Answer, AnswerDTO>
    {
        Task<AnswerDTO> Create(AnswerDTO entity);

        Task Delete(int key, string deleterId);

        Task<IEnumerable<AnswerDTO>> GetTopVoted(int count);

        Task<IEnumerable<AnswerDTO>> GetBottomVoted(int count);
    }
}
