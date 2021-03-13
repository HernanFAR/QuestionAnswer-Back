using Quicker.Interfaces.Service;
using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IAnswerService : IFullServiceAsync<int, Answer, AnswerDTO>
    {
    }
}
