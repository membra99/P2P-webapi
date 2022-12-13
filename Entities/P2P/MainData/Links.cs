using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Links", Schema = "P2P")]
    public class Links
    {
        public int LinkId { get; set; }

        public int UrlTableId { get; set; }
        [Required]
        public int LanguageId { get; set; }

        [StringLength(50)]
        public string Key { get; set; }
        public string Category { get; set; }

        public Language Language { get; set; }

        public UrlTable UrlTable { get; set; }
    }
}