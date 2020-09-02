using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("resources")]
    public class ResourceEntity
    {
        [Key, Column("res_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("resName", TypeName = "nvarchar(128)"), Required]
        public string Name { get; set; }

        public List<ResourceRoleEntity> ResourceRoles { get; set; }
    }
}
