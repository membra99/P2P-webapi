using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class AuthorODTO
    {
        public int AuthorID { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string AuthorName { get; set; }
        public string Tagline { get; set; }
        public string Image { get; set; }
    }
}