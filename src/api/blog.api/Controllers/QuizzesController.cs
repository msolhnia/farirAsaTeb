using blog.application.Contract.Api.Interface;
using blog.application.Contract.DTO.Quiz;
using blog.domain.entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("article/{articleId}")]
        public async Task<ActionResult<IEnumerable<QuizGetResponseDTO>>> GetQuizzesByArticleId(int articleId)
        {
            var quizzes = await _quizService.GetQuizzesByArticleId(articleId);
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizGetResponseDTO>> GetQuizById(int id)
        {
            var quiz = await _quizService.GetQuizById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddQuiz([FromBody] QuizCreateRequestDTO quizDto)
        {
            var newQuizId = await _quizService.AddQuiz(quizDto);
            return Ok(newQuizId);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateQuiz([FromBody] QuizUpdateRequestDTO quizDto)
        {
            await _quizService.UpdateQuiz(quizDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuiz(int id)
        {
            await _quizService.DeleteQuiz(id);
            return NoContent();
        }

        [HttpPost("{id}/submit")]
        public async Task<ActionResult> SubmitQuiz(int id, [FromBody] string userAnswer)
        {
            var result = await _quizService.SubmitQuiz(id, userAnswer);
            return Ok(new { IsCorrect = result });
        }
    }
}
