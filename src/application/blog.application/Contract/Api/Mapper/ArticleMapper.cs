using blog.application.Contract.Api.DTO.Article;
using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace blog.application.Contract.Api.Mapper
{
    public static class ArticleMapper
    {
        public static ArticleGetResponseDTO ConvertArticleModelToGetArticleResponseDTO(this ArticleModel value)
        {
            CultureInfo persianCulture = new CultureInfo("fa-IR");
            return new ArticleGetResponseDTO()
            {
                Title = value.Title,
                Content = value.Content,
                PublishedDate = value.PublishedDate.ToString("yyyy-MM-dd", persianCulture),
                Id = value.Id,
                Author = value.Author,
                Quizzes = value.Quizzes?.ConvertAll(quiz => quiz.ConvertQuizModelToQuizGetResponseDTO())
            };
        }
        public static ArticleModel ConvertArticleCreateRequestDTOToArticle(this ArticleCreateRequestDTO value)
        {
            return new ArticleModel
            {
                Title = value.Title,
                Content = value.Content,
                Author = value.Author,
                PublishedDate = value.PublishedDate
            };
        }

        public static ArticleModel ConvertArticleUpdateRequestDTOToArticle(this ArticleUpdateRequestDTO value)
        {
            return new ArticleModel
            {
                Id = value.Id,
                Title = value.Title,
                Content = value.Content,
                Author = value.Author,
                PublishedDate = value.PublishedDate
            };
        }
    }
}
