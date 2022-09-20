using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("PageArticles", Schema = "P2P")]
    public class PageArticles
    {
        public int PageArticleId { get; set; }

        [Required]
        public int PageId { get; set; }

        [Required]
        public int AcademyId { get; set; }

        public Page Page { get; set; }
        public Academy Academy { get; set; }
    }
}