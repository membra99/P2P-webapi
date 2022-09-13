using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Languages", Schema = "P2P")]  
    public class Language
    {
        public int LanguageId { get; set; }

        [Required]
        [StringLength(5)]
        public string LanguageName { get; set; }

        public ICollection<Testimonial> Testimonials { get; set; }
    }
}
