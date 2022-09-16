using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetFaqTitleByReviewIdODTO
    {
        public int FaqTitleId { get; set; }
        public int ReviewId { get; set; }
        public string Title { get; set; }

    }
}
