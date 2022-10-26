using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Author", Schema = "P2P")]
    public class Author
    {
        public int AuthorID { get; set; }
        public int LanguageId { get; set; }

        [StringLength(100)]
        public string AuthorName { get; set; }

        [StringLength(500)]
        public string Tagline { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        public Language Language { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}