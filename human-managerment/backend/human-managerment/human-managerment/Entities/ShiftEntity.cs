using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("Shifts")]
    public class ShiftEntity
    {
        [Key, Column("shi_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("shiName", TypeName = "nvarchar(256)"), Required]
        public string Name { get; set; }

        [Column("shiWorkStartTime", TypeName = "varchar(10)"), Required]
        public string WorkStartTime { get; set; }

        [Column("shiWorkEndTime", TypeName = "varchar(10)"), Required]
        public string WorkEndTime { get; set; }

        [Column("shiBreakStartTime", TypeName = "varchar(10)")]
        public string? BreakStartTime { get; set; }

        [Column("shiBreakEndTime", TypeName = "varchar(10)")]
        public string? BreakEndTime { get; set; }

        [Column("shiWorkingHoursNumber", TypeName = "double"), Required]
        public double WorkingHoursNumber { get; set; }

        [Column("shiWorkingDaysNumber", TypeName = "double"), Required]
        public double WorkingDaysNumber { get; set; }

    }
}
