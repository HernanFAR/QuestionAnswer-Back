using Microsoft.AspNetCore.Mvc;
using Quicker.Interfaces.WebApiController;
using Repository.DTO;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionAnswer.Interface
{
    public interface IAnswerController : ICloseControllerAsync<int, Answer, AnswerDTO>
    {
        Task<ActionResult<AnswerDTO>> Create(AnswerDTO entity);

        Task<ActionResult> Delete(int key);

        Task<ActionResult<IEnumerable<AnswerDTO>>> GetTopVoted(int count);

        Task<ActionResult<IEnumerable<AnswerDTO>>> GetBottomVoted(int count);
    }
}
