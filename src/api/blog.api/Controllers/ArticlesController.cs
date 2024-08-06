using blog.application.Contract.Api.Interface;
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
        public async Task<ActionResult<IEnumerable<ArticleModel>>> GetAllArticles()
        {
            var articles = await _articleService.GetAllArticles();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleModel>> GetArticleById(int id)
        {
            var article = await _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public async Task<ActionResult> AddArticle([FromBody] ArticleModel article)
        {
            await _articleService.AddArticle(article);
            return CreatedAtAction(nameof(GetArticleById), new { id = article.Id }, article);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticle(int id, [FromBody] ArticleModel article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            await _articleService.UpdateArticle(article);
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
