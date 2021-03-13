using Quicker.Abstracts.Service;
using Repository.DTO;
using Repository.Models;
using Service.Interfaces;
using System;

namespace Service
{
    public class QuestionService : FullServiceAsync<int, Question, QuestionDTO>, IQuestionService
    {
        public QuestionService(IServiceProvider service) : 
            base(service) { }
    }
}
