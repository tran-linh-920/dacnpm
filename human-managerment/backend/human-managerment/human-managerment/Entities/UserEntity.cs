using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{

    [Table("users")]
    public class UserEntity
    {
        [Key, Column("user_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("username", TypeName = "varchar(50)"), Required]
        public string Username { get; set; }

        [Column("password", TypeName = "varchar(256)"), Required]
        public string Password { get; set; }

        public List<UserRoleEntity> UserRoles { get; set; }

        public List<LogEntity> Logs { get; set; }
    }
}
