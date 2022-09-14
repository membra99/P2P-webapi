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
    public class Routes
    {
        public int RoutesId { get; set; }

        [Required]
        public int DataTypeId { get; set; }

        [Required]
        public int UrlTableId { get; set; }

        [Required]
        public int LanguageId { get; set; }

        //public int ReviewId { get; set; }

        public DataType DataType { get; set; }
        public UrlTable UrlTable { get; set; }
        public Language Language { get; set; }

        //public Review Review { get; set; }
    }
}