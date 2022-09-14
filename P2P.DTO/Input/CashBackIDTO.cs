using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class CashBackIDTO
    {
        public int CashBackId { get; set; }
        public int LanguageId { get; set; }
        //public int ReviewId { get; set; }
        public string CashBack_ca { get; set; }
        public string CashBack_terms { get; set; }
        public DateTime? Valid_Until { get; set; } //If IsCampaign is true - Valid Until is filled, Exclusive is null
        public bool? Exclusive { get; set; } //If IsCampaign is false - Exclusive is filled, Valid Until is null

        [Required]
        public bool IsCampaign { get; set; }
    }
}
