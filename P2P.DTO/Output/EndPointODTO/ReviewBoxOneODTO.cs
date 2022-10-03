using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class ReviewBoxOneODTO
    {
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public decimal? Interest { get; set; }

        public decimal? RatingCalculated { get; set; }
        public int? SecuredBy { get; set; }
        public bool? SecuredByCheck { get; set; }
        public string Bonus { get; set; }
        public string CustomMessage { get; set; }
        public bool? CompareButton { get; set; }
        public string Logo { get; set; }
        public bool? Recommended { get; set; }
    }
}