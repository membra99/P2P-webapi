using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class TestimonialIDTO
    {
        public int TestimonialId { get; set; }
        public int LanguageId { get; set; }
        public string TestimonialText { get; set; }
        public string FullName { get; set; }
        public string TagLine { get; set; }
    }
}
