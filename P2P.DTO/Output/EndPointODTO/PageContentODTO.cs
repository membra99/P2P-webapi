using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class PageContentODTO
    {
        public string Title { get; set; }
        public int PageId { get; set; }

        public List<GetParentReviewODTO> PopularReviews { get; set; }
        public List<PopularArticlesODTO> PopularArticles { get; set; }
        public string Image { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public string Content { get; set; }
        public int SerpId { get; set; }
        public string Subtitle { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
    }
}