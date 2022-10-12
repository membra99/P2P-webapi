using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetUrlODTO
    {
        public string Url { get; set; }
        public string DataTypeName { get; set; }
        public int LanguageID { get; set; }
        public int TableId { get; set; }
    }
}