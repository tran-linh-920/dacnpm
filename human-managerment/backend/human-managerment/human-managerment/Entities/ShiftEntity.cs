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

        [Column("shiWorkStartTime", TypeName = "time"), Required]
        public TimeSpan WorkStartTime { get; set; }

        [Column("shiWorkEndTime", TypeName = "time"), Required]
        public TimeSpan WorkEndTime { get; set; }

        [Column("shiBreakStartTime", TypeName = "time")]
        public TimeSpan? BreakStartTime { get; set; }

        [Column("shiBreakEndTime", TypeName = "time")]
        public TimeSpan? BreakEndTime { get; set; }

        [Column("shiWorkingHoursNumber", TypeName = "double"), Required]
        public double WorkingHoursNumber { get; set; }

        [Column("shiWorkingDaysNumber", TypeName = "double"), Required]
        public double WorkingDaysNumber { get; set; }

    }
}
