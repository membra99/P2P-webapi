using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class ReviewBoxFiveODTO
    {
        public List<ReviewAttributeODTO> Benefits { get; set; }
        public List<ReviewAttributeODTO> Disadvantages { get; set; }
    }
}