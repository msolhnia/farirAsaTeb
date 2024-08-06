using blog.application.Contract.Api.Interface;
using blog.application.Contract.DTO.Article;
using blog.application.Contract.infrastructure;
using blog.application.Contract.Mapper;
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

        public async Task<IEnumerable<ArticleGetResponseDTO>> GetAllArticles()
        {
            var articles = await _articleRepository.GetAll();
            return articles.Select(article => article.ConvertArticleModelToGetArticleResponseDTO());
        }

        public async Task<ArticleGetResponseDTO> GetArticleById(int id)
        {
            var article = await _articleRepository.GetById(id);
            return article?.ConvertArticleModelToGetArticleResponseDTO();
        }

        public async Task<int> AddArticle(ArticleCreateRequestDTO articleDto)
        {
            var article = articleDto.ConvertArticleCreateRequestDTOToArticle();
            await _articleRepository.Add(article);
            return article.Id; 
        }

        public async Task UpdateArticle(ArticleUpdateRequestDTO articleDto)
        {
            var article = articleDto.ConvertArticleUpdateRequestDTOToArticle();
            await _articleRepository.Update(article);
        }

        public async Task DeleteArticle(int id)
        {
            await _articleRepository.Delete(id);
        }
    }
}
