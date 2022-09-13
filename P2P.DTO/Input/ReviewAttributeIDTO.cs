using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class ReviewAttributeIDTO
    {
        public int ReviewAttributeId { get; set; }
        public int DataTypeId { get; set; }
        //public int ReviewId { get; set; }
        public int? Index { get; set; }
        public string Value { get; set; }
    }
}
