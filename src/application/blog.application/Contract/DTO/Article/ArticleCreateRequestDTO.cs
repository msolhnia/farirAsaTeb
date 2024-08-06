using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Contract.DTO.Article
{
    public class ArticleCreateRequestDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
