using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Contract.infrastructure
{
    public interface IArticleRepository
    {
        Task<IEnumerable<ArticleModel>> GetAll();
        Task<ArticleModel> GetById(int id);
        Task Add(ArticleModel article);
        Task Update(ArticleModel article);
        Task Delete(int id);
    }
}
