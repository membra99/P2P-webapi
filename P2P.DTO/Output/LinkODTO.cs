using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class LinkODTO
    {
        public int LinkId { get; set; }

        //public int UrlTableId { get; set; }
        //public string Url { get; set; }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public string Key { get; set; }
    }
}