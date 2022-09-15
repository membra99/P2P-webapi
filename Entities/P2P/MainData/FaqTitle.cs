using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("FaqTitles", Schema = "P2P")]
    public class FaqTitle
    {
        public int FaqPageTitleId { get; set; }
        public int? PageId { get; set; }
        public int? ReviewId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }


        public Page Page { get; set; }
        public Review Review { get; set; }
        public ICollection<FaqList> FaqLists { get; set; }
    }
}
