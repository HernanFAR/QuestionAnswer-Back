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

        protected override void PresetPropertiesBeforeCreating(Question entity)
        {
            entity.TotalVotes = 0;
            entity.UpVotes = 0;
            entity.DownVotes = 0;
        }

        protected override void PresetPropertiesBeforeUpdating(Question updated, Question original)
        {
            updated.TotalVotes = original.TotalVotes;
            updated.UpVotes = original.UpVotes;
            updated.DownVotes = original.DownVotes;
        }

        protected override void FilteringEntitiesBeforeUpdating(Question updated, Question original)
        {
            if (updated.QuestionAnswerUserId != original.QuestionAnswerUserId)
                throw new InvalidOperationException(nameof(updated.QuestionAnswerUserId));
        }

        public Task<IEnumerable<QuestionDTO>> GetQuestionsWithCategory(int categoryId)
            => FindManyWith(null, e => e.CategoryId == categoryId);

        public Task<IEnumerable<QuestionDTO>> GetTopVoted(int count)
            => FindManyWith(() => Context.Set<Question>()
                .OrderBy(e => e.UpVotes)
                .Take(count)
                .Include(e => e.Category)
                .AsNoTracking());

        public Task<IEnumerable<QuestionDTO>> GetBottomVoted(int count)
            => FindManyWith(() => Context.Set<Question>()
                .OrderBy(e => e.DownVotes)
                .Take(count)
                .Include(e => e.Category)
                .AsNoTracking());

        public Task<IEnumerable<QuestionDTO>> GetOfUser(string identityId)
            => FindManyWith(() => Context.Set<Question>()
                .OrderBy(e => e.Id)
                .Include(e => e.Category)
                .Where(e => e.QuestionAnswerUserId == identityId)
                .AsNoTracking());

        public async Task Delete(int key, string deleterId)
        {
            var entity = await Context.Set<Question>()
                .FindAsync(key);

            if (entity.QuestionAnswerUserId != deleterId)
                throw new InvalidOperationException(nameof(entity.QuestionAnswerUserId));

            await base.Delete(key);
        }
    }
}
