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

        public DbSet<QuestionVote> QuestionVotes { get; set; }

        public DbSet<AnswerVote> AnswerVotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity => 
            {
                entity.HasData(
                    new Category { Id = 1, Name = "Vida" }, 
                    new Category { Id = 2, Name = "Juegos" }, 
                    new Category { Id = 3, Name = "Amor" }, 
                    new Category { Id = 4, Name = "Dolores" }, 
                    new Category { Id = 5, Name = "Miselaneo" }
                );
            });

            modelBuilder.Entity<QuestionAnswerUser>(entity => 
            {
                entity.HasData(
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

            modelBuilder.Entity<QuestionVote>(entity => {
                entity.HasOne(e => e.Question)
                    .WithMany(e => e.QuestionVotes)
                    .HasForeignKey(fk => fk.QuestionId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.QuestionAnswerUser)
                    .WithMany(e => e.QuestionVotes)
                    .HasForeignKey(fk => fk.QuestionAnswerUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<AnswerVote>(entity => {
                entity.HasOne(e => e.Answer)
                    .WithMany(e => e.AnswerVotes)
                    .HasForeignKey(fk => fk.AnswerId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.QuestionAnswerUser)
                    .WithMany(e => e.AnswerVotes)
                    .HasForeignKey(fk => fk.QuestionAnswerUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
