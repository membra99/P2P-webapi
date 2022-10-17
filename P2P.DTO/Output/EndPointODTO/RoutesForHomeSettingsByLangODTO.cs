using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class RoutesForHomeSettingsByLangODTO
    {
        public int RoutesId { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public int UrlTableId { get; set; }
        public string URL { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int TableId { get; set; }
        public string ExternalLinkKey { get; set; }
    }
}