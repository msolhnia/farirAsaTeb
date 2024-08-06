using blog.application.Contract.Api.DTO.Quiz;
using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Contract.Api.DTO.Article
{
    public class ArticleGetResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string PublishedDate { get; set; }
        public List<QuizGetResponseDTO>? Quizzes { get; set; }
    }
}
