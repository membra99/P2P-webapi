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
        public int? AcademyId { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public string PageTitle { get; set; }
        public string Excerpt { get; set; }
    }
}