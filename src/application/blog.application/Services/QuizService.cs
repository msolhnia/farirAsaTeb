using blog.application.Contract.Api.Interface;
using blog.application.Contract.DTO.Quiz;
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
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<IEnumerable<QuizGetResponseDTO>> GetQuizzesByArticleId(int articleId)
        {
            var quizzes = await _quizRepository.GetByArticleId(articleId);
            return quizzes.Select(quiz => quiz.ConvertQuizModelToQuizGetResponseDTO());
        }

        public async Task<QuizGetResponseDTO> GetQuizById(int id)
        {
            var quiz = await _quizRepository.GetById(id);
            return quiz?.ConvertQuizModelToQuizGetResponseDTO();
        }

        public async Task<int> AddQuiz(QuizCreateRequestDTO quizDto)
        {
            var quiz = quizDto.ConvertQuizCreateRequestDTOToQuiz();
            await _quizRepository.Add(quiz);
            return quiz.Id; 
        }

        public async Task UpdateQuiz(QuizUpdateRequestDTO quizDto)
        {
            var quiz = quizDto.ConvertQuizUpdateRequestDTOToQuiz();
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
