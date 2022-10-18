using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("Roles", Schema = "Users")]
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
