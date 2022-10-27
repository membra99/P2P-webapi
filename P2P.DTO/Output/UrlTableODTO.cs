using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class UrlTableODTO
    {
        public int UrlTableId { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public string URL { get; set; }
        public int? TableId { get; set; }
    }
}