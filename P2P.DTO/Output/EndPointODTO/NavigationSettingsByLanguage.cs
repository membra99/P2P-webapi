using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class NavigationSettingsByLanguageODTO
    {
        public int NavigationSettingsId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int AcademyRoute { get; set; }
        public string AcademyRouteLink { get; set; }
        public int BonusRoute { get; set; }
        public string BonusRouteLink { get; set; }
        public int HomeRoute { get; set; }
        public string HomeRouteLink { get; set; }
        public int NewsRoute { get; set; }
        public string NewsRouteLink { get; set; }
        public int ReviewsRoute { get; set; }
        public string ReviewsRouteLink { get; set; }
        public List<SettingsAttributeODTO> ReviewsRoutes { get; set; }
        public List<SettingsAttributeODTO> Reviews { get; set; }
    }
}