using blog.application.Contract.Api.Interface;
using blog.application.Contract.infrastructure;
using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<ArticleModel>> GetAllArticles()
        {
            return await _articleRepository.GetAll();
        }

        public async Task<ArticleModel> GetArticleById(int id)
        {
            return await _articleRepository.GetById(id);
        }

        public async Task AddArticle(ArticleModel article)
        {
            await _articleRepository.Add(article);
        }

        public async Task UpdateArticle(ArticleModel article)
        {
            await _articleRepository.Update(article);
        }

        public async Task DeleteArticle(int id)
        {
            await _articleRepository.Delete(id);
        }
    }
}
