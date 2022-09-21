using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class SettingsAttributeODTO
    {
        public int SettingsAttributeId { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public int SettingsDataTypeId { get; set; }
        public string SettingsDataTypeName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Value { get; set; }
    }
}