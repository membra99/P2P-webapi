using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class PermissionIDTO
    {
        public int PermissionId { get; set; }
        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public int RoleId { get; set; }
        public int DataTypeId { get; set; }
    }
}
