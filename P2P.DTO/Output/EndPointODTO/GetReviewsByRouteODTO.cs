using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetReviewsByRouteODTO
    {
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Availability { get; set; }
        public int? SerpId { get; set; }
        public int? Count { get; set; }
        public decimal? RiskReturn { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }
        public List<ReviewBoxOneODTO> ReviewBoxOne { get; set; }
        public List<ReviewBoxTwoODTO> ReviewBoxTwo { get; set; }
        public List<ReviewBoxThreeODTO> ReviewBoxThree { get; set; }
        public List<ReviewBoxFourODTO> ReviewBoxFour { get; set; }
        public List<ReviewBoxFiveODTO> ReviewBoxFive { get; set; }
        public List<StatisticsODTO> Statistics { get; set; }
        public List<CompanyInfoODTO> CompanyInfo { get; set; }
    }
}