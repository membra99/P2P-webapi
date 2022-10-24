using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class FooterSettingsIDTO
    {
        public int FooterSettingsId { get; set; }
        public int LanguageId { get; set; }
        public int? FacebookLink { get; set; }
        public string FacebookLinkUrl { get; set; }
        public int? LinkedInLink { get; set; }
        public string LinkedInLinkUrl { get; set; }
        public int? PodcastLink { get; set; }
        public string PodcastLinkUrl { get; set; }
        public int? TwitterLink { get; set; }
        public string TwitterLinkUrl { get; set; }
        public int? YoutubeLink { get; set; } //Url Table
        public string YoutubeLinkUrl { get; set; }
        public string CopyrightNotice { get; set; }
        public string FooterNote { get; set; }
        public List<SettingsAttributeIDTO> SettingsAttributes { get; set; }
    }
}