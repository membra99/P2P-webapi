using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Blogs", Schema = "P2P")]
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public int? LanguageId { get; set; }
        public int? SerpId { get; set; }
        public string SelectedPopularArticle { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }

        [StringLength(200)]
        public string PageTitle { get; set; }

        [StringLength(200)]
        public string Excerpt { get; set; }

        public string Content { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Language Language { get; set; }
        public Serp Serp { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public ICollection<FaqTitle> FaqTitles { get; set; }
    }
}