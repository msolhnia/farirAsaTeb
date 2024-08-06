using blog.application.Contract.Api.Interface;
using blog.application.Contract.DTO.Article;
using blog.domain.entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleGetResponseDTO>>> GetAllArticles()
        {
            var articles = await _articleService.GetAllArticles();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleGetResponseDTO>> GetArticleById(int id)
        {
            var article = await _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public async Task<ActionResult> AddArticle([FromBody] ArticleCreateRequestDTO articleDto)
        {
            var newArticleId = await _articleService.AddArticle(articleDto);
            return Ok(newArticleId);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateArticle([FromBody] ArticleUpdateRequestDTO articleDto)
        {
            await _articleService.UpdateArticle(articleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            await _articleService.DeleteArticle(id);
            return NoContent();
        }
    }
}
