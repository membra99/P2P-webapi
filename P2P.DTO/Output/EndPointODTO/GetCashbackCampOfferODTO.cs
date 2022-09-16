using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetCashbackCampOfferODTO
    {
        public int CashBackId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public string CashBack_ca { get; set; }
        public string CashBack_terms { get; set; }
        public DateTime? Valid_Until { get; set; } 
        public bool? Exclusive { get; set; } 
        public bool IsCampaign { get; set; }

        public List<ReviewContentDropdownODTO> reviews { get; set; }
    }
}
