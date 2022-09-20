using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class PageArticlesODTO
    {
        public int PageArticleId { get; set; }
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public int AcademyId { get; set; }
        public string Title { get; set; }
    }
}