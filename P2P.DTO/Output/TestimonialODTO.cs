using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class TestimonialODTO
    {
        public int TestimonialId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string TestimonialText { get; set; }
        public string FullName { get; set; }
        public string TagLine { get; set; }
    }
}
