using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.domain.entity
{
    public class QuizModel
    {
        [Key]
        public int Id { get; set; }        
        public string Question { get; set; }
        public string Options { get; set; }
        public string CorrectAnswer { get; set; }
        public ArticleModel Article { get; set; }   
    }
}
