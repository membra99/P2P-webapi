using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class FooterSettingsODTO
    {
        public int FooterSettingsId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int? FacebookLink { get; set; } //Url Table - Column UrlId
        public string FacebookUrl { get; set; } //Url Table - Column URL
        public int? LinkedInLink { get; set; } //Url Table - Column UrlId
        public string LinkedInUrl { get; set; } //Url Table - Column URL
        public int? PodcastLink { get; set; } //Url Table - Column UrlId
        public string PodcastUrl { get; set; } //Url Table - Column URL
        public int? TwitterLink { get; set; } //Url Table - Column UrlId
        public string TwitterUrl { get; set; } //Url Table - Column URL
        public int? YoutubeLink { get; set; } //Url Table - Column UrlId
        public string YoutubeUrl { get; set; } //Url Table - Column URL
        public string CopyrightNotice { get; set; }
        public string FooterNote { get; set; }

        public List<SettingsAttributeODTO> aItemAnchor { get; set; }
        public List<SettingsAttributeODTO> pItemAnchor { get; set; }

        public List<SettingsAttributeODTO> aItemLink { get; set; }

        public List<SettingsAttributeODTO> pItemLink { get; set; }
    }
}