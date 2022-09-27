using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class StatisticsODTO
    {
        public int? OperatingSince { get; set; }
        public long? Investors { get; set; }
        public long? InvestorsEarnings { get; set; }
        public int? AveragePortfolio { get; set; }
        public long? TotalInvested { get; set; }
        public string FinancialReport { get; set; }
        public long? InvestorsLoss { get; set; }
        public string StatisticsOtherCurrency { get; set; }
        public int? ReportLink { get; set; }
        public string StatisticsCurrency { get; set; }
    }
}