using Quicker.Abstracts.Service;
using Repository.DTO;
using Repository.Models;
using Service.Interfaces;
using System;

namespace Service
{
    public class AnswerService : FullServiceAsync<int, Answer, AnswerDTO>, IAnswerService
    {
        public AnswerService(IServiceProvider service) : 
            base(service) { }
    }
}
