using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class NewsFeedODTO
    {
        public int NewsFeedId { get; set; }
        public int? ReviewId { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int? UrlTableId { get; set; }
        public string URL { get; set; }
        public string NewsText { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Market { get; set; }
        public bool RedFlag { get; set; }
        public string TagLine { get; set; }
    }
}