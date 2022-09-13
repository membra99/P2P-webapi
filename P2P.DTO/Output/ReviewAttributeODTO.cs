using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class ReviewAttributeODTO
    {
        public int ReviewAttributeId { get; set; }

        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        //public Review Review { get; set; } Da li vraca ceo Review?
        public int? Index { get; set; }
        public string Value { get; set; }
    }
}
