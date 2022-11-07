using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("ImagesInfo", Schema = "P2P")]
    public class ImagesInfo
    {
        public int ImageId { get; set; }

        [StringLength(100)]
        public string AltText { get; set; }

        public string Caption { get; set; }
        public int? AwsUrl { get; set; }
        public UrlTable UrlTable { get; set; }
    }
}