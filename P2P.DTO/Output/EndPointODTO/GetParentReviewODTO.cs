using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetParentReviewODTO
    {
        public int ReviewId { get; set; }
        public decimal? Stars { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public int? LinkTo { get; set; }
        public bool? NewPlatform { get; set; }
        public decimal? Interest { get; set; }
        public int? SecuredBy { get; set; }
        public int? Count { get; set; }
        public string Guarantee { get; set; }
        public bool? IsSecured { get; set; }
        public string ExternalLinkKey { get; set; }
        public string CustomMessage { get; set; }
        public bool? Recommended { get; set; }
        public bool? CompareButton { get; set; }
    }
}