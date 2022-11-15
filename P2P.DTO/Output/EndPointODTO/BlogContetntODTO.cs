using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class BlogContetntODTO
    {
        public int BlogId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string PageTitle { get; set; }
        public string Excerpt { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string RouteName { get; set; }
    }
}