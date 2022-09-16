using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetPageODTO : PageODTO
    {
        public bool EditContent { get; set; }
        public List<ReviewContentDropdownODTO> ReviewContentDropdowns { get; set; }
        public List<PopularArticlesODTO> PopularArticles { get; set; }
        public List<int> SelectedPopularArticles { get; set; }
        public string DropdownSelectedId { get; set; }
        public string SelectedLanguage { get; set; }
    }
}
