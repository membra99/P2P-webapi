using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData.Settings
{
    [Table("HomeSettings", Schema = "Settings")]
    public class HomeSettings
    {
        public int HomeSettingsId { get; set; }
        public int? NewsUrl { get; set; }
        public int? ReviewId { get; set; }
        public int? ReviewUrl { get; set; }
        public int? SerpId { get; set; }
        public int? AcademyUrl { get; set; }
        public int? BonusUrl { get; set; }
        public int? LanguageId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public decimal? Returned { get; set; }
        public int? Investment { get; set; }
        public int? Platforms { get; set; }

        [StringLength(100)]
        public string TestimonialH2 { get; set; }

        [StringLength(100)]
        public string FeaturedH2 { get; set; }

        //[StringLength(50)]
        //public string Platform { get; set; }

        public UrlTable NewsUrls { get; set; }
        public UrlTable ReviewUrls { get; set; }
        public UrlTable AcademyUrls { get; set; }
        public UrlTable BonusUrls { get; set; }
        public Review Review { get; set; }
        public Serp Serp { get; set; }
        public Language Language { get; set; }
    }
}