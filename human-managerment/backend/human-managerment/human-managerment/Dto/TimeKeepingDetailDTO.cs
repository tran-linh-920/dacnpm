using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class TimeKeepingDetailDTO
    {
        public long Id { get; set; }

        public long employeeId { get; set; }

        public string employeeName { get; set; }

        public DateTime timeStart { get; set; }

        public string timeEnd { get; set; }

        public int timeWorking { get; set; }

        public long timeKeepingId  { get; set; }

        public string shift { get; set; }
        
        public int status { get; set; }
    }
}
