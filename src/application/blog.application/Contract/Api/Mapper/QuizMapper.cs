using blog.application.Contract.Api.DTO.Quiz;
using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Contract.Api.Mapper
{
    public static class QuizMapper
    {
        public static QuizGetResponseDTO ConvertQuizModelToQuizGetResponseDTO(this QuizModel value)
        {
            return new QuizGetResponseDTO
            {
                Id = value.Id,
                ArticleId = value.ArticleId,
                Question = value.Question,
                Options = value.Options,
                CorrectAnswer = value.CorrectAnswer
            };
        }

        public static QuizModel ConvertQuizCreateRequestDTOToQuiz(this QuizCreateRequestDTO value)
        {
            return new QuizModel
            {
                ArticleId = value.ArticleId,
                Question = value.Question,
                Options = value.Options,
                CorrectAnswer = value.CorrectAnswer
            };
        }

        public static QuizModel ConvertQuizUpdateRequestDTOToQuiz(this QuizUpdateRequestDTO value)
        {
            return new QuizModel
            {
                Id = value.Id,
                Question = value.Question,
                Options = value.Options,
                CorrectAnswer = value.CorrectAnswer
            };
        }
    }
}
