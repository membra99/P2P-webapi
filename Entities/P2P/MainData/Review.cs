using Entities.P2P.MainData.Settings;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.P2P.MainData
{
    [Table("Review", Schema = "P2P")]
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        public int SerpId { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public int? FacebookUrl { get; set; } //Url Table

        public int? TwitterUrl { get; set; } //Url Table

        public int? LinkedInUrl { get; set; } //Url Table

        public int? YoutubeUrl { get; set; } //Url Table

        public int? InstagramUrl { get; set; } //Url Table

        public int? ReportLink { get; set; }//Url Table

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Logo { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Interest { get; set; }

        public int? SecuredBy { get; set; }

        [Required]
        public bool SecuredByCheck { get; set; }

        [Required]
        public bool NotSecured { get; set; }

        [StringLength(100)]
        public string Bonus { get; set; }

        [StringLength(500)]
        public string CustomMessage { get; set; }

        [Required]
        public bool CompareButton { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? RiskReturn { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Usability { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Liquidity { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Support { get; set; }

        [StringLength(100)]
        public string Features { get; set; }

        [Required]
        public bool AutoInvest { get; set; }

        [Required]
        public bool SecondaryMarket { get; set; }

        [Required]
        public bool Promotion { get; set; }

        public int? MinInvestment { get; set; }

        [StringLength(100)]
        public string DiversificationOtherCurrency { get; set; }

        public int? Countries { get; set; }

        public int? LoanOriginators { get; set; }

        public int? LoanType { get; set; }

        [StringLength(20)]
        public string InterestRange { get; set; }

        public int? MinLoanPerion { get; set; }

        public int? MaxLoanPerion { get; set; }

        public int? OperatingSince { get; set; }

        public long Earnings { get; set; }

        public long TotalLoanValue { get; set; }

        public long NumberOfInvestors { get; set; }

        public long InvestorsLoss { get; set; }

        public int? PortfolioSize { get; set; }

        [StringLength(100)]
        public string FinancialReport { get; set; }

        [StringLength(50)]
        public string StatisticsOtherCurrency { get; set; }

        [Required]
        public bool BuybackGuarantee { get; set; }

        [Required]
        public bool PersonalGuarantee { get; set; }

        [Required]
        public bool Mortage { get; set; }

        [Required]
        public bool Collateral { get; set; }

        [Required]
        public bool NoProtection { get; set; }

        [Required]
        public bool CryptoAssets { get; set; }

        [StringLength(100)]
        public string LegalName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public bool LiveChat { get; set; }

        [StringLength(50)]
        public string OpeningHours { get; set; }

        [Required]
        public bool TableOfContents { get; set; }

        [Required]
        public bool CashbackBonus { get; set; }

        public int? DiversificationMinInvest { get; set; }

        [StringLength(50)]
        public string ProtectionScheme { get; set; }

        public string ReviewContent { get; set; }

        [StringLength(5)]
        public string StatisticsCurrency { get; set; }

        public int? Cryptoloan { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? RatingCalculated { get; set; }

        [Required]
        public bool NewPlatform { get; set; }

        [Required]
        public bool Recommended { get; set; }

        [StringLength(200)]
        public string OfficeAddress { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RiskAndReturn { get; set; }

        public int? Availability { get; set; }

        public int? Count { get; set; }

        public Language Language { get; set; }

        public UrlTable Rev_FacebookUrl { get; set; }
        public UrlTable Rev_TwitterUrl { get; set; }
        public UrlTable Rev_LinkedInUrl { get; set; }
        public UrlTable Rev_YoutubeUrl { get; set; }
        public UrlTable Rev_InstagramUrl { get; set; }
        public UrlTable Rev_ReportLink { get; set; }

        public Serp Serp { get; set; }
        public ICollection<Routes> Routes { get; set; }
        public ICollection<FaqTitle> FaqTitles { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<ReviewAttribute> ReviewAttribute { get; set; }
        public ICollection<CashBack> CashBacks { get; set; }
        public ICollection<PagesSettings> PagesSettings { get; set; }
        public ICollection<NewsFeed> NewsFeeds { get; set; }
        public ICollection<HomeSettings> HomeSettings { get; set; }
    }
}