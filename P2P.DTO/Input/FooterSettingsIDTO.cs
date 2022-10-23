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
        public int FacebookLink { get; set; }
        public int LinkedInLink { get; set; }
        public int PodcastLink { get; set; }
        public int TwitterLink { get; set; }
        public int YoutubeLink { get; set; } //Url Table
        public string CopyrightNotice { get; set; }
        public string FooterNote { get; set; }
        public List<SettingsAttributeIDTO> SettingsAttributes { get; set; }
    }
}