using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class ReviewDataODTO
    {
        public string Content { get; set; }
        public int PageId { get; set; }
        public string Page_Title { get; set; }
        public Task<CampaignBonusODTO> ReviewData { get; set; }
        public int SerpId { get; set; }
        public string SerpDescription { get; set; }
        public string SerpTitle { get; set; }
        public string Subtitle { get; set; }
    }
}