using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class JobDTO
    {
        public long Id { get; set; }
        public string JobTitle { get; set; }
        public string JobBio { get; set; }
        //public double MinSalary { get; set; }
        //public double MaxSalary { get; set; }
        public List<JobHistoryDTO> JobHistorys { get; set; }
        public JobLevelDTO JobLevel { get; set; }
    }
}
