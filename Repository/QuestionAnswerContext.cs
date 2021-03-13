using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class QuestionAnswerContext : IdentityDbContext<QuestionAnswerUser, IdentityRole, string>
    {
        public QuestionAnswerContext(DbContextOptions<QuestionAnswerContext> options) : 
            base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionVote> QuestionVotes { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<AnswerVote> AnswerVotes { get; set; }
    }
}
