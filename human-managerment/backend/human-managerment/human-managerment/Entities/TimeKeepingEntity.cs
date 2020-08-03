using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    public class TimeKeepingEntity
    {

        [Key, Column("id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("tk_totalWorkTime", TypeName = "INT")]
        public int totalWorkTime { get; set; }

        [Column("tk_minimumTime", TypeName = "INT"), Required]
        public int minimumTime { get; set; }

        [Column("tk_timeLate", TypeName = "INT")]
        public int timeLate { get; set; }

        [Column("tk_overTime", TypeName = "INT")]
        public int overTime { get; set; }

        [Column("tk_note", TypeName = "nvarchar(256)")]
        public String note { get; set; }

        [Column("tk_dateStar", TypeName = "nvarchar(256)"), Required]
        public String dateStart { get; set; }

        [Column("tk_dateEnd", TypeName = "nvarchar(256)")]
        public String dateEnd { get; set; }

        [Column("tk_status", TypeName = "INT")]
        public int status { get; set; }


        public long idEmployee { get; set; }
    }

}
