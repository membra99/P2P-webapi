using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Permissions", Schema = "Users")]
    public class Permission
    {
        public int PermissionId { get; set; }

        public int UserId { get; set; }

        public int LanguageId { get; set; }

        public int RoleId { get; set; }
        public int? DataTypeId { get; set; }
        public Language Language { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
        public DataType DataType { get; set; }
    }
}
