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
        Task<IEnumerable<QuizModel>> GetQuizzesByArticleId(int articleId);
        Task<QuizModel> GetQuizById(int id);
        Task AddQuiz(QuizModel quiz);
        Task UpdateQuiz(QuizModel quiz);
        Task DeleteQuiz(int id);
        Task<bool> SubmitQuiz(int id, string userAnswer);
    }
}
