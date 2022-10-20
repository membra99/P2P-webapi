using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetPageODTO
    {
        public bool EditContent { get; set; }
        public List<ReviewContentDropdownODTO> ReviewContentDropdowns { get; set; }
        public List<PopularArticlesODTO> PopularArticles { get; set; }
        public List<int> SelectedPopularArticles { get; set; }
        public string DropdownSelectedId { get; set; }
        public int SelectedLanguage { get; set; }
        public int PageId { get; set; }
        public int SerpId { get; set; }
        public int ReviewId { get; set; }
        public int DataTypeId { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
    }
}