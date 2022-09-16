using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetCashbackCampaignBonusODTO
    {
        public int CashBackId { get; set; }
        public int? ReviewId { get; set; }
        public DateTime? Valid_Until { get; set; } //If IsCampaign is true - Valid Until is filled, Exclusive is null
        public decimal? RatingCalculated { get; set; }
        public bool? Exclusive { get; set; } //If IsCampaign is false - Exclusive is filled, Valid Until is null
    }
}