using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class NavigationSettingsODTO
    {
        public int NavigationSettingsId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Academy { get; set; }
        public string Bonus { get; set; }
        public string Home { get; set; }
        public string News { get; set; }
        public string Reviews { get; set; }
        public int? AcademyRoute { get; set; }
        public string AcademyRouteUrl { get; set; }
        public int? BonusRoute { get; set; }
        public string BonusRouteUrl { get; set; }
        public int? HomeRoute { get; set; }
        public string HomeRouteUrl { get; set; }
        public int? NewsRoute { get; set; }
        public string NewsRouteUrl { get; set; }
        public int? ReviewsRoute { get; set; }
        public string ReviewsRouteUrl { get; set; }
    }
}