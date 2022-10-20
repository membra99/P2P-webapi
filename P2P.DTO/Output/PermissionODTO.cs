using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class PermissionODTO
    {
        public int PermissionId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
    }
}
