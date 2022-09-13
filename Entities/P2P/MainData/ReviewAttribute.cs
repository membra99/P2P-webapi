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
        //public int DataTypeId { get; set; }
        //public int ReviewId { get; set; }
        public int? Index { get; set; }
        [StringLength(100)]
        public string Value { get; set; }

        //public ICollection<DataType> DataTypes { get; set; }
        //public ICollection<Review> Reviews { get; set; }
    }
}
