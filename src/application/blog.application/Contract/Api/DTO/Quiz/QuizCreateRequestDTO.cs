﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.application.Contract.Api.DTO.Quiz
{
    public class QuizCreateRequestDTO
    {
        public int ArticleId { get; set; }
        public string Question { get; set; }
        public string Options { get; set; }
        public string CorrectAnswer { get; set; }
    }
}