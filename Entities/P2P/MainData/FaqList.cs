using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("FaqLists", Schema = "P2P")]
    public class FaqList
    {
        public int FaqPageListId { get; set; }
        public int FaqTitleId { get; set; }

        [StringLength(500)]
        public string Question { get; set; }

        [StringLength(2000)]
        public string Answer { get; set; }

        [Required]
        public int Position { get; set; }

        public FaqTitle FaqTitle { get; set; }
    }
}