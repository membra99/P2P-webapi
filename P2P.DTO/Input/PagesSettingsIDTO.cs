using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class PagesSettingsIDTO
    {
        public int PagesSettingsId { get; set; }
        public int LanguageId { get; set; }
        public int SerpId { get; set; }
        public int DataTypeId { get; set; }
        public int? ReviewId { get; set; }
        public string Title { get; set; }
    }
}