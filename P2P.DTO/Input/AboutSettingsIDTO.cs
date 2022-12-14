using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class AboutSettingsIDTO
    {
        public int AboutSettingsId { get; set; }
        public int? SerpId { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public string Subtitle { get; set; }
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
        public List<SettingsAttributeIDTO> SettingsAttributes { get; set; }
    }
}