using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.P2P.MainData.Settings
{
    [Table("NavigationSettings", Schema = "Settings")]
    public class NavigationSettings
    {
        public int NavigationSettingsId { get; set; }

        public int LanguageId { get; set; }

        [StringLength(50)]
        public string Academy { get; set; }

        [StringLength(50)]
        public string Bonus { get; set; }

        [StringLength(50)]
        public string Home { get; set; }

        [StringLength(50)]
        public string News { get; set; }

        [StringLength(50)]
        public string Reviews { get; set; }

        [StringLength(50)]
        public string More { get; set; }

        public int? AcademyRoute { get; set; }
        public int? BonusRoute { get; set; }
        public int? HomeRoute { get; set; }
        public int? NewsRoute { get; set; }
        public int? ReviewsRoute { get; set; }
        public Language Language { get; set; }
        public UrlTable AcademyRouteLink { get; set; }
        public UrlTable BonusRouteLink { get; set; }
        public UrlTable HomeRouteLink { get; set; }
        public UrlTable NewsRouteLink { get; set; }
        public UrlTable ReviewsRouteLink { get; set; }
    }
}