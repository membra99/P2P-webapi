using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("UrlLanguages", Schema = "P2P")]
    public class UrlLanguages
    {
        public int UrlLanguagesID { get; set; }
        public int DataTypeId { get; set; }
        public string URL { get; set; }
        public int LanguageId { get; set; }
        public int TableID { get; set; }
        public string GUID { get; set; }

        public DataType DataType { get; set; }
        public Language Language { get; set; }
    }
}
