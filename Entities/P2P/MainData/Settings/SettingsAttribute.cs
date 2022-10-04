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

        [Required]
        public int DataTypeId { get; set; }

        [Required]
        public int SettingsDataTypeId { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required]
        public string Value { get; set; }

        public int Index { get; set; }

        public NavigationSettings NavigationSettings { get; set; }
        public DataType DataType { get; set; }

        public DataType SettingsDataType { get; set; }
        public Language Language { get; set; }
    }
}