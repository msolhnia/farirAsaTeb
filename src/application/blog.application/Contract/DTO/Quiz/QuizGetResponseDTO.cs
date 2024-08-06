using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Contract.DTO.Quiz
{
    public class QuizGetResponseDTO
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Question { get; set; }
        public string Options { get; set; }
        public string CorrectAnswer { get; set; }

    }
}
