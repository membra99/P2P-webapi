using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class NewsFeedIDTO
    {
        public int NewsFeedId { get; set; }
        public int? ReviewId { get; set; }
        public int LanguageId { get; set; }
        public int? UrlTableId { get; set; }
        public string NewsText { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Market { get; set; }
        public bool RedFlag { get; set; }
        public string TagLine { get; set; }
    }
}