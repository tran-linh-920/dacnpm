using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("roles")]
    public class RoleEntity
    {
        [Key, Column("rol_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("rolName", TypeName = "nvarchar(128)"), Required]
        public string Name { get; set; }

        public List<UserRoleEntity> UserRoles { get; set; }
        public List<ResourceRoleEntity> ResourceRoles { get; set; }
    }
}
