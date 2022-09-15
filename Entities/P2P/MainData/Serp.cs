using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Serps", Schema = "P2P")]
    public class Serp
    {
        public int SerpId { get; set; }
        public int DataTypeId { get; set; }

        [StringLength(50)]
        public string SerpTitle { get; set; }

        [StringLength(200)]
        public string SerpDescription { get; set; }

        [StringLength(50)]
        public string Subtitle { get; set; }

        public int TableId { get; set; }
        public DataType DataType { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}