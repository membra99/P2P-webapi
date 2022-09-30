using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetUrlTableByDataTypeIdAndLangODTO
    {
        public List<int?> UrlTableId { get; set; }
        public List<string> URL { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}