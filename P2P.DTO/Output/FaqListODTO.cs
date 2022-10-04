using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class FaqListODTO
    {
        public int FaqListId { get; set; }
        public int FaqTitleId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Position { get; set; }
    }
}