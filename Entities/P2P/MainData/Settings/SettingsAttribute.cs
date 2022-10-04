using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData.Settings
{
    [Table("SettingsAttribute", Schema = "Settings")]
    public class SettingsAttribute
    {
        public int SettingsAttributeId { get; set; }
        public int DataTypeId { get; set; }
        public int SettingsDataTypeId { get; set; }
        public int LanguageId { get; set; }

        [Required]
        public string Value { get; set; }

        public int? Index { get; set; }
        public DataType DataType { get; set; }

        public DataType SettingsDataType { get; set; }
        public Language Language { get; set; }
    }
}