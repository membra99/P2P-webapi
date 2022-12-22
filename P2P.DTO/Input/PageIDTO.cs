using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class PageIDTO
    {
        public int PageId { get; set; }
        public int? SerpId { get; set; }
        public int? ReviewId { get; set; }
        public int? DataTypeId { get; set; }
        public int LanguageId { get; set; }
        public string DefaultCrypto { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string SelectedPopularArticle { get; set; }
        public string Platforms { get; set; }
        public double? InvestmentAmount { get; set; }
        public double? MonthlyContribution { get; set; }
        public int? InvestmentPeriodInMonths { get; set; }
    }
}