using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetCashbackOfferBonusODTO
    {
        public int CashBackId { get; set; }
        public int? ReviewId { get; set; }
        public bool? Exclusive { get; set; } //If IsCampaign is false - Exclusive is filled, Valid Until is null

        public decimal? RatingCalculated { get; set; }
    }
}