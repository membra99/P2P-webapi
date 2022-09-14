using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class RoutesODTO
    {
        public int RoutesId { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public int UrlTableId { get; set; }
        public string URL { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int ReviewId { get; set; }
        public string Name { get; set; }
    }
}