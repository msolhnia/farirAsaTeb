using blog.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Contract.infrastructure
{
    public interface IQuizRepository
    {
        Task<IEnumerable<QuizModel>> GetByArticleId(int articleId);
        Task<QuizModel> GetById(int id);
        Task Add(QuizModel quiz);
        Task Update(QuizModel quiz);
        Task Delete(int id);
    }
}
