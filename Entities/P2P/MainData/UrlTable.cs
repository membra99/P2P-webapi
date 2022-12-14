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
        [StringLength(500)]
        public string URL { get; set; }

        public int? TableId { get; set; }
        public DataType DataType { get; set; }
        public ICollection<Links> Links { get; set; }
        public ICollection<FooterSettings> FacebookUrls { get; set; }
        public ICollection<FooterSettings> LinkedInUrls { get; set; }
        public ICollection<FooterSettings> PodcastUrls { get; set; }
        public ICollection<FooterSettings> TwitterUrls { get; set; }
        public ICollection<FooterSettings> YoutubeUrls { get; set; }
        public ICollection<Routes> Routes { get; set; }
        public ICollection<Review> Rev_FacebookUrls { get; set; }
        public ICollection<Review> Rev_LinkedIdUrls { get; set; }
        public ICollection<Review> Rev_TwitterUrls { get; set; }
        public ICollection<Review> Rev_YoutubeUrls { get; set; }
        public ICollection<Review> Rev_InstagramUrls { get; set; }
        public ICollection<Review> Rev_ReportLinks { get; set; }
        public ICollection<Academy> Academies { get; set; }
        public ICollection<NewsFeed> NewsFeeds { get; set; }
        public ICollection<HomeSettings> NewsUrls { get; set; }
        public ICollection<HomeSettings> ReviewUrls { get; set; }
        public ICollection<HomeSettings> AcademyUrls { get; set; }
        public ICollection<HomeSettings> BonusUrls { get; set; }
        public ICollection<NavigationSettings> AcademyRouteLinks { get; set; }
        public ICollection<NavigationSettings> BonusRouteLinks { get; set; }
        public ICollection<NavigationSettings> HomeRouteLinks { get; set; }
        public ICollection<NavigationSettings> NewsRouteLinks { get; set; }
        public ICollection<NavigationSettings> ReviewsRouteLinks { get; set; }
        public ICollection<SettingsAttribute> SettingsAttributes { get; set; }
        public ICollection<ImagesInfo> ImagesInfos { get; set; }
    }
}