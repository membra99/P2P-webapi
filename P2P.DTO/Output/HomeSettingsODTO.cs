using P2P.DTO.Output.EndPointODTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class HomeSettingsODTO
    {
        public int HomeSettingsId { get; set; }
        public int? NewsUrl { get; set; }
        public string NewsUrlLink { get; set; }
        public int? Platforms { get; set; }
        public int? ReviewUrl { get; set; }
        public string ReviewUrlLink { get; set; }
        public int? SerpId { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public string Subtitle { get; set; }
        public int? AcademyUrl { get; set; }
        public string AcademyUrlLink { get; set; }
        public int? BonusUrl { get; set; }
        public string BonusUrlLink { get; set; }
        public int? LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Title { get; set; }
        public decimal? Returned { get; set; }
        public int? Investment { get; set; }
        public string TestimonialH2 { get; set; }
        public string FeaturedH2 { get; set; }

        public string Platform { get; set; }

        public List<RoutesForHomeSettingsByLangODTO> LinkToUrl { get; set; }
        public List<ReviewODTO> ReviewList { get; set; } = new List<ReviewODTO>();

        public List<SettingsAttributeODTO> TrackH2 { get; set; }
        public List<SettingsAttributeODTO> TrackH3 { get; set; }
        public List<SettingsAttributeODTO> Trackparahraph { get; set; }
    }
}