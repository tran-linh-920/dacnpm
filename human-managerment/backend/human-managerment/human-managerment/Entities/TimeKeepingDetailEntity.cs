using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("TimeKeepingDetail")]
    public class TimeKeepingDetailEntity
    {
        [Key, Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        public long employeeId { get; set; }

        public string employeeName { get; set; }

        public DateTime timeStart { get; set; }

        public DateTime? timeEnd { get; set; }

        public int timeWorking { get; set; }

        public long timeKeepingId { get; set; }

        public string shift { get; set; }

        public int status { get; set; }
    }
}
