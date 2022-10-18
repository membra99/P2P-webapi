﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class UserODTO
    {
        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public int RoleId { get; set; }
        public string LanguageName { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
