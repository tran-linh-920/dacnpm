using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{

    [Table("departments")]
    public class DepartmentEntity
    {
        [Key, Column("dep_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("depName", TypeName = "nvarchar(256)"), Required]
        public string Name { get; set; }

        [Column("depBio", TypeName = "nvarchar(500)")]
        public string? Bio { get; set; }

        [Column("depIsActive", TypeName = "bit"), Required]
        public bool IsActive { get; set; }

        public List<JobHistoryEntity> JobHistorys { get; set; }


    }
}
