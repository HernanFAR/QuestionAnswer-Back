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

            modelBuilder.Entity<QuestionAnswerUser>(e => 
            {
                e.HasData(
                    new QuestionAnswerUser
                    {
                        Id = "ac0bfb48-782b-48f9-b425-20c56f60a59a",
                        SecurityStamp = "9f8f72f9-7380-4e0a-817e-414f630b7367",
                        ConcurrencyStamp = "876acc24-639b-47d0-a3aa-b75e1fe94b54",
                        Email = "h.f.alvarez.r@gmail.com",
                        UserName = "Enryu19_",
                        IsAdmin = true,
                        LockoutEnabled = true,
                        NormalizedEmail = "H.F.ALVAREZ.R@GMAIL.COM",
                        NormalizedUserName = "ENRYU19_",
                        PhoneNumber = "+56 9 4979 8355"
                    }    
                );
            });
        }
    }
}
