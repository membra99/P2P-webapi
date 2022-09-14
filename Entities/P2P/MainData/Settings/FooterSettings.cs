using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData.Settings
{
    [Table("FooterSettings", Schema = "P2P")]
    public class FooterSettings
    {
        public int FooterSettingsId { get; set; }
        public int LanguageId { get; set; }
        public int FacebookLink { get; set; } //Url Table
        public int LinkedInLink { get; set; } //Url Table
        public int PodcastLink { get; set; } //Url Table
        public int TwitterLink { get; set; } //Url Table
        public int YoutubeLink { get; set; } //Url Table
        public string CopyrightNotice { get; set; }
        public string FooterNote { get; set; }

        public Language Language { get; set; }
        //public UrlTable UrlTable { get; set; }
    }
}
