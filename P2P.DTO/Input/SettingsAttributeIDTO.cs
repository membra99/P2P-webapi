using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class SettingsAttributeIDTO
    {
        public int SettingsAttributeId { get; set; }
        public int DataTypeId { get; set; }
        public int SettingsDataTypeId { get; set; }
        public int LanguageId { get; set; }
        public string Value { get; set; }
        public int? UrlTableId { get; set; }
        public int? Index { get; set; }
    }
}