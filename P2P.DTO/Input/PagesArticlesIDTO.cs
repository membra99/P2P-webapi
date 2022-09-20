using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class PagesArticlesIDTO
    {
        public int PageArticleId { get; set; }
        public int PageId { get; set; }
        public int AcademyId { get; set; }
    }
}