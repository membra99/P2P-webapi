using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Pages", Schema = "P2P")]
    public class Page
    {
        public int PageId { get; set; }
        public int? SerpId { get; set; }
        public int? ReviewId { get; set; }
        public int? DataTypeId { get; set; }
        public int LanguageId { get; set; }

        [StringLength(100)]
        public string SelectedPopularArticle { get; set; }

        [StringLength(100)]
        public string PageTitle { get; set; }

        public string Content { get; set; }

        public Language Language { get; set; }
        public DataType DataType { get; set; }
        public Serp Serp { get; set; }
        public Review Review { get; set; }
        public ICollection<FaqTitle> FaqTitles { get; set; }
        public ICollection<PageArticles> PageArticles { get; set; }
    }
}