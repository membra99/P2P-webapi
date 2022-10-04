using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetFaqTitleByBlogIdODTO
    {
        public int FaqTitleId { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
    }
}