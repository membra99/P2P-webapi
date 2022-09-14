using Entities.P2P.MainData.Settings;
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

        public ICollection<Links> Links { get; set; }

        public ICollection<FooterSettings> FacebookUrls { get; set; }
        public ICollection<FooterSettings> LinkedInUrls { get; set; }
        public ICollection<FooterSettings> PodcastUrls { get; set; }
        public ICollection<FooterSettings> TwitterUrls { get; set; }
        public ICollection<FooterSettings> YoutubeUrls { get; set; }
        public ICollection<Routes> Routes { get; set; }
    }
}