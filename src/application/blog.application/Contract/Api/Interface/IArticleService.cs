using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Contract.Api.Interface
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleModel>> GetAllArticles();
        Task<ArticleModel> GetArticleById(int id);
        Task AddArticle(ArticleModel article);
        Task UpdateArticle(ArticleModel article);
        Task DeleteArticle(int id);
    }
}
