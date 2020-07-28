using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class JobHistoryDTO
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long JobId { get; set; }
        public JobDTO Job { get; set; }
        public long DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
