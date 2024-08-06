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
    public class ArticleRepository : IArticleRepository
    {
        private readonly FarirContext _context;

        public ArticleRepository(FarirContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArticleModel>> GetAll()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<ArticleModel> GetById(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task Add(ArticleModel article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ArticleModel article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }
    }
}
