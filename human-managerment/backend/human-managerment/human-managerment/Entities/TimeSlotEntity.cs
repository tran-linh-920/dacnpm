using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace human_managerment_backend.Entities
{
    [Table("TimeSlots")]
    public class TimeSlotEntity
    {
        [Key, Column("ts_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("tsName", TypeName = "nvarchar(256)"), Required]
        public String Name { get; set; }

        [Column("tsBio", TypeName = "varchar(500)")]
        public String Bio { get; set; }

        [Column("tsPeriod", TypeName = "varchar(128)"), Required]
        public String Period { get; set; }

        public List<WorkingTimeDetailEntity> WorkingTimeDetails { get; set; }
    }
}
