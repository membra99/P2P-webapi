using Entities.P2P.MainData.Settings;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public ICollection<NavigationSettings> NavigationSettings { get; set; }
<<<<<<< HEAD
        public ICollection<Links> Links { get; set; }
=======
        public ICollection<FooterSettings> FooterSettings { get; set; }
>>>>>>> 186d17d685686315b7f6917d11c064fb55097daf
    }
}