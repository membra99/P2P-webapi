using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("UrlTables", Schema = "P2P")]
    public class UrlTable
    {
        public int UrlTableId { get; set; }
        public int DataTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string URL { get; set; }
        public int TableId { get; set; }
        public DataType DataType { get; set; }
    }
}
