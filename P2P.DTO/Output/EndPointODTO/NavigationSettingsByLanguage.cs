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
        public string AcademyItem { get; set; }
        public string AcademyLink { get; set; }
        public string BonusItem { get; set; }
        public string BonusLink { get; set; }
        public string HomeItem { get; set; }
        public string HomeLink { get; set; }
        public string NewsItem { get; set; }
        public string NewsLink { get; set; }
        public string ReviewsItem { get; set; }
        public string ReviewsLink { get; set; }
        public List<SettingsAttributeODTO> ReviewsRoutes { get; set; }
        public List<SettingsAttributeODTO> Reviews { get; set; }
    }
}