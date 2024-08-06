using blog.domain.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.infrastructure.Data.Persist
{
    public class FarirContext: DbContext
    {
        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<QuizModel> Quizzes { get; set; }

        public FarirContext(DbContextOptions<FarirContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
