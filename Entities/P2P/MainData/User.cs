﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Users", Schema = "Users")]
    public class User
    {

        public int UserId { get; set; }

        public int LanguageId { get; set; }

        public int RoleId { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Blog> Blogs { get; set; }    
        public Language Language { get; set; }
        public Role Role { get; set; }
    }
}