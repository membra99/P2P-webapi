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
    [Table("Serps", Schema = "P2P")]
    public class Serp
    {
        public int SerpId { get; set; }
        public int DataTypeId { get; set; }

        [StringLength(200)]
        public string SerpTitle { get; set; }

        [StringLength(500)]
        public string SerpDescription { get; set; }

        [StringLength(200)]
        public string Subtitle { get; set; }

        public int TableId { get; set; }
        public DataType DataType { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<Academy> Academies { get; set; }
        public ICollection<PagesSettings> PagesSettings { get; set; }
        public ICollection<HomeSettings> HomeSettings { get; set; }
        public ICollection<AboutSettings> AboutSettings { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}