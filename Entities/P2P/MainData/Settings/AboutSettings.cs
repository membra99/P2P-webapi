using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData.Settings
{
    [Table("AboutSettings", Schema = "Settings")]
    public class AboutSettings
    {
        public int AboutSettingsId { get; set; }
        public int? SerpId { get; set; }
        public int? LanguageId { get; set; }

        [StringLength(1000)]
        public string Paragraph { get; set; }

        [StringLength(100)]
        public string TeamH2 { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string VideoCode { get; set; }

        [StringLength(500)]
        public string VideoDescription { get; set; }

        [StringLength(100)]
        public string Section1H2 { get; set; }

        [StringLength(100)]
        public string Section1H3 { get; set; }

        [StringLength(100)]
        public string Section2H2 { get; set; }

        [StringLength(500)]
        public string Section2Paragraph { get; set; }

        [StringLength(100)]
        public string TestimonialH2 { get; set; }

        public Serp Serp { get; set; }
        public Language Language { get; set; }
    }
}