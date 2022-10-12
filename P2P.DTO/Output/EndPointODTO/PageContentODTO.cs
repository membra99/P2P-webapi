using System.Collections.Generic;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class PageContentODTO
    {
        public string Title { get; set; }
        public int PageId { get; set; }
        public string Page_Title { get; set; }
        public GetCampaignBonusODTO ReviewData { get; set; }
        public List<GetParentReviewODTO> PopularReviews { get; set; }
        public PopularArticlesForPageContentODTO PopularArticles { get; set; }
        public string Image { get; set; }
        public string Tag { get; set; }
        public string Content { get; set; }
        public int SerpId { get; set; }
        public string Subtitle { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
    }
}