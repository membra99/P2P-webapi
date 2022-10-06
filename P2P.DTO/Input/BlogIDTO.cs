using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class BlogIDTO
    {
        public int BlogId { get; set; }
        public int? LanguageId { get; set; }
        public int? SerpId { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public int? SelectedPopularArticle { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public string PageTitle { get; set; }
        public string Excerpt { get; set; }
    }
}