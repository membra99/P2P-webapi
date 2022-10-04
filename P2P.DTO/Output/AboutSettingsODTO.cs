using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class AboutSettingsODTO
    {
        public int AboutSettingsId { get; set; }
        public int? SerpId { get; set; }
        public int? LanguageId { get; set; }
        public string Paragraph { get; set; }
        public string TeamH2 { get; set; }
        public string Title { get; set; }
        public string VideoCode { get; set; }
        public string VideoDescription { get; set; }
        public string Section1H2 { get; set; }
        public string Section1H3 { get; set; }
        public string Section2H2 { get; set; }
        public string Section2Paragraph { get; set; }
        public string TestimonialH2 { get; set; }
        public List<SettingsAttributeODTO> memberImageUrl { get; set; }
        public List<SettingsAttributeODTO> memberName { get; set; }
        public List<SettingsAttributeODTO> memberRole { get; set; }
    }
}