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
        public ICollection<Links> Links { get; set; }
        public ICollection<FooterSettings> FooterSettings { get; set; }
        public ICollection<Routes> Routes { get; set; }
        public ICollection<CashBack> CashBacks { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Page> Pages { get; set; }
    }
}