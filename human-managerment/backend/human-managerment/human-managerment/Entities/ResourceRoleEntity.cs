using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("ResourceRoles")]
    public class ResourceRoleEntity
    {
        [Column("res_id")]
        public long ResourceId { get; set; }
        public ResourceEntity Resource { get; set; }

        [Column("role_id")]
        public long RoleId { get; set; }
        public RoleEntity Role { get; set; }

        [Column("permissions")]
        public string? permissions { get; set; }
    }
}
