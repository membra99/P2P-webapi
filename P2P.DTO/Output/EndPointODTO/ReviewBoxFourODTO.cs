using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class ReviewBoxFourODTO
    {
        public int? MinInvestment { get; set; }
        public int? Country { get; set; }
        public int? LoanOriginators { get; set; }
        public int? LoanType { get; set; }
        public string LoanPeriod { get; set; }
        public string Interest { get; set; }
        public string Currency { get; set; }
    }
}