using Microsoft.EntityFrameworkCore;
using Quicker.Abstracts.Service;
using Repository.DTO;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class QuestionService : FullServiceAsync<int, Question, QuestionDTO>, IQuestionService
    {
        public QuestionService(IServiceProvider service) : 
            base(service) { }

        protected override IQueryable<Question> Query()
            => Context.Set<Question>()
                .OrderBy(e => e.Id)
                .Include(e => e.Category)
                .AsNoTracking();

        public Task<IEnumerable<QuestionDTO>> GetQuestionsWithCategory(int categoryId)
            => FindManyWith(null, e => e.CategoryId == categoryId);

        public Task<IEnumerable<QuestionDTO>> GetTopVoted(int count)
            => FindManyWith(() => Context.Set<Question>()
                .OrderBy(e => e.Votes)
                .Take(count)
                .Include(e => e.Category)
                .AsNoTracking());

        public Task<IEnumerable<QuestionDTO>> GetBottomVoted(int count)
            => FindManyWith(() => Context.Set<Question>()
                .OrderByDescending(e => e.Votes)
                .Take(count)
                .Include(e => e.Category)
                .AsNoTracking());

    }
}
