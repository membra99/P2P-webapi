﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class BlogODTO
    {
        public int BlogId { get; set; }
        public int? LanguageId { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public string Subtitle { get; set; }
        public int? SelectedPopularArticle { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public string PageTitle { get; set; }
        public string Excerpt { get; set; }
    }
}