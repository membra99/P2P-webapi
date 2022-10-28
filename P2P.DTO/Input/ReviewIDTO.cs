using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class ReviewIDTO
    {
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public int? ReportLink { get; set; }
        public string ReportLinkURL { get; set; }
        public int? SerpId { get; set; }

        public int? SecuredBy { get; set; }
        public int? MinInvestment { get; set; }
        public int? Countries { get; set; }
        public int? LoanOriginators { get; set; }
        public int? MinLoanPerion { get; set; }
        public int? MaxLoanPerion { get; set; }
        public int? OperatingSince { get; set; }
        public int? LoanType { get; set; }
        public int? PortfolioSize { get; set; }
        public int? Availability { get; set; }
        public int? Count { get; set; }
        public int? Cryptoloan { get; set; }
        public int? DiversificationMinInvest { get; set; }
        public long? Earnings { get; set; }
        public long? TotalLoanValue { get; set; }
        public long? NumberOfInvestors { get; set; }
        public long? InvestorsLoss { get; set; }
        public decimal? RiskReturn { get; set; }
        public decimal? Usability { get; set; }
        public decimal? Liquidity { get; set; }
        public decimal? Support { get; set; }
        public decimal? Interest { get; set; }
        public decimal? RiskAndReturn { get; set; }
        public decimal? RatingCalculated { get; set; }
        public string Logo { get; set; }

        public string Bonus { get; set; }
        public string CustomMessage { get; set; }
        public string Features { get; set; }
        public string DiversificationOtherCurrency { get; set; }
        public string InterestRange { get; set; }
        public string FinancialReport { get; set; }
        public string StatisticsOtherCurrency { get; set; }
        public string LegalName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
        public string StatisticsCurrency { get; set; }
        public string ProtectionScheme { get; set; }
        public string ReviewContent { get; set; }
        public string OfficeAddress { get; set; }
        public bool? SecuredByCheck { get; set; }
        public bool? NotSecured { get; set; }
        public bool? CompareButton { get; set; }
        public bool? AutoInvest { get; set; }
        public bool? SecondaryMarket { get; set; }
        public bool? Promotion { get; set; }
        public bool? BuybackGuarantee { get; set; }
        public bool? PersonalGuarantee { get; set; }
        public bool? Mortage { get; set; }
        public bool? Collateral { get; set; }
        public bool? NoProtection { get; set; }
        public bool? CryptoAssets { get; set; }
        public bool? LiveChat { get; set; }
        public bool? TableOfContents { get; set; }
        public bool? CashbackBonus { get; set; }
        public bool? NewPlatform { get; set; }
        public bool? Recommended { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}