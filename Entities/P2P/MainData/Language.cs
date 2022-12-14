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
        public ICollection<Academy> Academies { get; set; }
        public ICollection<PagesSettings> PagesSettings { get; set; }
        public ICollection<NewsFeed> NewsFeeds { get; set; }
        public ICollection<HomeSettings> HomeSettings { get; set; }
        public ICollection<AboutSettings> AboutSettings { get; set; }
        public ICollection<SettingsAttribute> SettingsAttributes { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<Author> Author { get; set; }
        public ICollection<UrlLanguages> UrlLanguages { get; set; }
    }
}