using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("NewsFeed", Schema = "P2P")]
    public class NewsFeed
    {
        public int NewsFeedId { get; set; }
        public int? ReviewId { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public int? UrlTableId { get; set; }

        [StringLength(500)]
        public string NewsText { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        public bool Market { get; set; }

        [Required]
        public bool RedFlag { get; set; }

        [StringLength(500)]
        public string TagLine { get; set; }

        public Review Review { get; set; }
        public Language Language { get; set; }
        public UrlTable UrlTable { get; set; }
    }
}