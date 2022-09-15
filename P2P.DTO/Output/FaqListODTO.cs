using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class FaqListODTO
    {
        public int FaqPageListId { get; set; }
        public int FaqPageTitleId { get; set; }
        public string FaqPageTitle { get; set; }
        public string Qestion { get; set; }
        public string Answer { get; set; }
        public int Position { get; set; }
    }
}
