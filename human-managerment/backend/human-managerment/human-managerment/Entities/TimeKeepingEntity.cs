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

        [Column("totalWorkTime", TypeName = "INT")]
        public int totalWorkTime { get; set; }

        [Column("minimumTime", TypeName = "INT"), Required]
        public int minimumTime { get; set; }

        [Column("timeLate", TypeName = "INT")]
        public int timeLate { get; set; }

        [Column("overTime", TypeName = "INT")]
        public int overTime { get; set; }

        [Column("note", TypeName = "nvarchar(256)")]
        public String note { get; set; }

        [Column("dateStar", TypeName = "nvarchar(256)"), Required]
        public String dateStart { get; set; }

        [Column("dateEnd", TypeName = "nvarchar(256)")]
        public String dateEnd { get; set; }

        // trang thai hiện thị buổi sáng chiều
        public int morning { get; set; }
        public int afternoon { get; set; }

        [Column("status", TypeName = "INT")]
        public int status { get; set; }

        public long idEmployee { get; set; }


        public void plusWorkingTime(int time)
        {
            this.totalWorkTime += time;
        }
    }

}
