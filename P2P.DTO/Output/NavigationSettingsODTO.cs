using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class NavigationSettingsODTO
    {
        public int NavigationSettingsId { get; set; }
        public int LanguageId { get; set; }
        public int AcademyRoute { get; set; }
        public int BonusRoute { get; set; }
        public int HomeRoute { get; set; }
        public int NewsRoute { get; set; }
        public int ReviewsRoute { get; set; }
        public List<SettingsAttributeODTO> SettingsAttributes { get; set; }
    }
}