using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class JobDTO
    {
        public long Id { get; set; }
        public String JobTitle { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
        public List<JobHistoryDTO> JobHistorys { get; set; }
    }
}
