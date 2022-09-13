using NetTopologySuite.Simplify;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Testimonials", Schema="P2P")]
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public int? LanguageId { get; set; }

        [Required]
        [StringLength(500)]
        public string TestimonialText { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string TagLine { get; set; }

        public Language Language { get; set; }


    }
}
