using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("ReviewAttributes", Schema = "P2P")]
    public class ReviewAttribute
    {
        public int ReviewAttributeId { get; set; }

        [Required]
        public int DataTypeId { get; set; }

        //public int ReviewId { get; set; }
        public int? Index { get; set; }

        [StringLength(100)]
        public string Value { get; set; }

        public DataType DataType { get; set; }
    }
}
