using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class JobHistoryDetailDTO
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long JobId { get; set; }
        public string JobName { get; set; }
        public int SalaryLevel { get; set; }
        public DateTime SalaryAssignDate { get; set; }

        public JobHistoryDetailDTO(long employeeId, string employeeName, long jobId, string jobName, int salaryLevel, DateTime salaryAssignDate)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            JobId = jobId;
            JobName = jobName;
            SalaryLevel = salaryLevel;
            SalaryAssignDate = salaryAssignDate;
        }
    }
}
