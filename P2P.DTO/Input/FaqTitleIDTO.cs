using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class FaqTitleIDTO
    {
        public int FaqPageTitleId { get; set; }
        public int? PageId { get; set; }
        public int? ReviewId { get; set; }
        public string Title { get; set; }
    }
}
