using blog.application.Contract.DTO.Quiz;
using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Contract.Api.Interface
{
    public interface IQuizService
    {
        Task<IEnumerable<QuizGetResponseDTO>> GetQuizzesByArticleId(int articleId);
        Task<QuizGetResponseDTO> GetQuizById(int id);
        Task<int> AddQuiz(QuizCreateRequestDTO quizDto);
        Task UpdateQuiz(QuizUpdateRequestDTO quizDto);
        Task DeleteQuiz(int id);
        Task<bool> SubmitQuiz(int id, string userAnswer);
    }
}
