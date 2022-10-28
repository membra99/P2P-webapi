using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetBlogsByRouteODTO
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public int? LanguageId { get; set; }
        public int? SerpId { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public List<BlogODTO> Blogs { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? AuthorId { get; set; }
        public string PageTitle { get; set; }
        public string Excerpt { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}