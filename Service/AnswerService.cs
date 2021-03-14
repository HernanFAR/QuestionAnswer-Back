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
    public class AnswerService : OpenServiceAsync<int, Answer, AnswerDTO>, IAnswerService
    {
        public AnswerService(IServiceProvider service) :
            base(service)
        { }

        public async Task Delete(int key, string deleterId)
        {
            var deleter = await Context.Set<QuestionAnswerUser>()
                .FindAsync(deleterId);

            var answer = await Context.Set<Answer>()
                .FindAsync(key);

            if (!deleter.IsAdmin || answer.QuestionAnswerUserId != deleterId)
                throw new InvalidOperationException(nameof(answer.QuestionAnswerUserId));

            await base.Delete(key);
        }

        public Task<IEnumerable<AnswerDTO>> GetTopVoted(int count)
            => FindManyWith(() => Context.Set<Answer>()
                .OrderBy(e => e.Votes)
                .Take(count)
                .AsNoTracking());

        public Task<IEnumerable<AnswerDTO>> GetBottomVoted(int count)
            => FindManyWith(() => Context.Set<Answer>()
                .OrderByDescending(e => e.Votes)
                .Take(count)
                .AsNoTracking());
    }
}
