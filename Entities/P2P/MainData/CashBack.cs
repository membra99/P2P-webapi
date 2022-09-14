using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    public class CashBack
    {
        public int CashBackId { get; set; }
        public int LanguageId { get; set; }
        //public int ReviewId { get; set; }
        [StringLength(200)]
        public string CashBack_ca { get; set; }
        [StringLength(500)]
        public string CashBack_terms { get; set; }
        public DateTime? Valid_Until { get; set; } //If IsCampaign is true - Valid Until is filled, Exclusive is null
        public bool? Exclusive { get; set; } //If IsCampaign is false - Exclusive is filled, Valid Until is null
        public bool IsCampaign { get; set; }

        public Language Language { get; set; }
        //public Review Review { get; set; }
    }
}
