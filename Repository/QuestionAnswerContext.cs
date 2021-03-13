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
            base(options)
        { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(e => 
            {
                e.HasData(
                    new Category { Id = 1, Name = "Vida" }, 
                    new Category { Id = 2, Name = "Juegos" }, 
                    new Category { Id = 3, Name = "Amor" }, 
                    new Category { Id = 4, Name = "Dolores" }, 
                    new Category { Id = 5, Name = "Miselaneo" }
                );
            });
        }
    }
}
