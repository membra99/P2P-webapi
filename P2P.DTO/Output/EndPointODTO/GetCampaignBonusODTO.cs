using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetCampaignBonusODTO
    {
        public int CashBackId { get; set; }
        public int ReviewId { get; set; }
        public bool? Exclusive { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int? Count { get; set; }
        public string CashbackCta { get; set; }
        public decimal Stars { get; set; }
        public string ExternalLinkKey { get; set; }
        public int ReviewUrlId { get; set; }
        public string Terms { get; set; }
        public List<ReviewBoxThreeODTO> ReviewBoxThree { get; set; }
        public List<ReviewBoxFourODTO> ReviewBoxFour { get; set; }
        public List<ReviewBoxFiveODTO> ReviewBoxFive { get; set; }
    }
}