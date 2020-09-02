using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("UserRoles")]
    public class UserRoleEntity
    {
        [Column("user_id")]
        public long UserId { get; set; }    
        public UserEntity User { get; set; }

        [Column("role_id")]
        public long RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}
