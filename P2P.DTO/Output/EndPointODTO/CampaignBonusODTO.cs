using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class CampaignBonusODTO
    {
        public List<GetCampaignBonusODTO> CashBackOffer { get; set; }
        public List<GetCampaignBonusODTO> CashBackCampaign { get; set; }
    }
}