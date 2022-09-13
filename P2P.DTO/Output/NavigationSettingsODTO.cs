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
        public string LanguageName { get; set; }
        public string Academy { get; set; }
        public string Bonus { get; set; }
        public string Home { get; set; }
        public string News { get; set; }
        public string Reviews { get; set; }
        public int AcademyRoute { get; set; }
        public int BonusRoute { get; set; }
        public int HomeRoute { get; set; }
        public int NewsRoute { get; set; }
        public int ReviewsRoute { get; set; }
    }
}
