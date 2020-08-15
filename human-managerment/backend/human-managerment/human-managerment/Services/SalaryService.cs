using HumanManagermentBackend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface SalaryService
    {
        public bool CanCounting(DateTime countingDate);
        public bool DoSalaryCounting();
        public bool DoSalaryCounting(long empId);
        public JobHistoryDetailDTO DoSalaryIncreasing(long empId, int jobLevel);
        public int CountAllSalaryHistories();
        public List<SalaryHistoryDTO> FindSalaryHistories(int page, int limit);
    }
}
