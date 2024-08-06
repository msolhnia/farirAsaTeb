using blog.application.Contract.infrastructure;
using blog.domain.entity;
using blog.infrastructure.Data.Persist;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.infrastructure.Data.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly FarirContext _context;

        public QuizRepository(FarirContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizModel>> GetByArticleId(int articleId)
        {
            return await _context.Quizzes.Where(q => q.ArticleId == articleId).ToListAsync();
        }

        public async Task<QuizModel> GetById(int id)
        {
            return await _context.Quizzes.FindAsync(id);
        }

        public async Task Add(QuizModel quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task Update(QuizModel quiz)
        {
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                await _context.SaveChangesAsync();
            }
        }
    }
}
