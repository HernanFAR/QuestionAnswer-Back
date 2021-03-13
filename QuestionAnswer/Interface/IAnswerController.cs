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
    public interface IAnswerController : IOpenControllerAsync<int, Answer, AnswerDTO>
    {
    }
}
