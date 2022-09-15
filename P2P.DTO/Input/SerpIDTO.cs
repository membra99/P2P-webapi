using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class SerpIDTO
    {
        public int SerpId { get; set; }
        public int DataTypeId { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public string Subtitle { get; set; }
        public int TableId { get; set; }
    }
}
