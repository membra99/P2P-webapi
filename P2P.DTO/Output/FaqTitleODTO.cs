using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class FaqTitleODTO
    {
        public int FaqTitleId { get; set; }
        public int? PageId { get; set; }
        public string Page_Title { get; set; }
        public int? ReviewId { get; set; }
        public string Name { get; set; } 
        public string Title { get; set; }
    }
}
