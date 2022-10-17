using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Users", Schema = "P2P")]
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public ICollection<Blog> Blogs { get; set; }

        [Required]
        public Language Language { get; set; }
    }
}