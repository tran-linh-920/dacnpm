using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace human_managerment_backend.Entities
{
    [Table("WorkingTimes")]
    public class WorkingTimeEntity
    {
        [Key, Column("wt_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("wtName", TypeName = "nvarchar(256)"), Required]
        public String Name { get; set; }

        [Column("wtBio", TypeName = "varchar(500)")]
        public String Bio { get; set; }

        public List<WorkingTimeDetailEntity> WorkingTimeDetails { get; set; }
    }
}
