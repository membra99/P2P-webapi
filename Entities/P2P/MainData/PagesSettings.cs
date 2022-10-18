using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("PagesSettings", Schema = "Settings")]
    public class PagesSettings
    {
        public int PagesSettingsId { get; set; }
        public int LanguageId { get; set; }
        public int SerpId { get; set; }
        public int DataTypeId { get; set; }
        public string Platform { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(200)]
        public string PageSettingsSubtitle { get; set; }

        public Language Language { get; set; }
        public Serp Serp { get; set; }
        public DataType DataType { get; set; }
    }
}