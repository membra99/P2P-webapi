using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class AcademyIDTO
    {
        public int AcademyId { get; set; }
        public int? LanguageId { get; set; }
        public string Url { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public string FeaturedImage { get; set; }
        public string Tag { get; set; }
        public string TitleOverview { get; set; }
        public string Excerpt { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}