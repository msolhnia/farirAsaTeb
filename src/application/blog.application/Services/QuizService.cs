using blog.application.Contract.Api.Interface;
using blog.application.Contract.infrastructure;
using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<IEnumerable<QuizModel>> GetQuizzesByArticleId(int articleId)
        {
            return await _quizRepository.GetByArticleId(articleId);
        }

        public async Task<QuizModel> GetQuizById(int id)
        {
            return await _quizRepository.GetById(id);
        }

        public async Task AddQuiz(QuizModel quiz)
        {
            await _quizRepository.Add(quiz);
        }

        public async Task UpdateQuiz(QuizModel quiz)
        {
            await _quizRepository.Update(quiz);
        }

        public async Task DeleteQuiz(int id)
        {
            await _quizRepository.Delete(id);
        }

        public async Task<bool> SubmitQuiz(int id, string userAnswer)
        {
            var quiz = await _quizRepository.GetById(id);
            if (quiz == null)
            {
                return false;
            }

            return quiz.CorrectAnswer == userAnswer;
        }
    }
}
