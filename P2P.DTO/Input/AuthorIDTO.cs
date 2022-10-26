using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class AuthorIDTO
    {
        public int AuthorID { get; set; }
        public int LanguageId { get; set; }
        public string AuthorName { get; set; }
        public string Tagline { get; set; }
        public string Image { get; set; }
    }
}