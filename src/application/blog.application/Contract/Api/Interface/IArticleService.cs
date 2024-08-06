using blog.application.Contract.DTO.Article;
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
        Task<IEnumerable<ArticleGetResponseDTO>> GetAllArticles();
        Task<ArticleGetResponseDTO> GetArticleById(int id);
        Task<int> AddArticle(ArticleCreateRequestDTO articleDto);
        Task UpdateArticle(ArticleUpdateRequestDTO articleDto);
        Task DeleteArticle(int id);
    }
}
