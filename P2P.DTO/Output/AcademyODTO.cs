using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class AcademyODTO
    {
        public int AcademyId { get; set; }
        public int? UrlTableId { get; set; }
        public string URL { get; set; }
        public int? SerpId { get; set; }
        public int? LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Title { get; set; }

        public string FeaturedImage { get; set; }

        public string Tag { get; set; }

        public string TitleOverview { get; set; }

        public string Excerpt { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}