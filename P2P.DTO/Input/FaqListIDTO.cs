using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class FaqListIDTO
    {
        public int FaqPageListId { get; set; }
        public int FaqTitleId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Position { get; set; }
    }
}
