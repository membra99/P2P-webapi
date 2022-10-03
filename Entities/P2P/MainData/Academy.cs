using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Academy", Schema = "P2P")]
    public class Academy
    {
        public int AcademyId { get; set; }
        public int? UrlTableId { get; set; }
        public int? SerpId { get; set; }
        public int? LanguageId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(100)]
        public string FeaturedImage { get; set; }

        [StringLength(50)]
        public string Tag { get; set; }

        [StringLength(100)]
        public string TitleOverview { get; set; }

        [StringLength(500)]
        public string Excerpt { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public UrlTable UrlTable { get; set; }
        public Serp Serp { get; set; }
        public Language Language { get; set; }
        public ICollection<PageArticles> PageArticles { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}