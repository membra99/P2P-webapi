using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class PopularArticlesForPageContentODTO
    {
        public int AcademyId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Stars { get; set; }
        public string Path { get; set; }
        public string Excerpt { get; set; }
        public string Tag { get; set; }
    }
}