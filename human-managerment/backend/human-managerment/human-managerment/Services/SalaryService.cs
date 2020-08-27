using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Models;
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
        public bool DoSalaryCounting(long empId, Date countingDate);
        public JobHistoryDetailDTO DoSalaryIncreasing(long empId, int jobLevel);
        public int CountAllSalaryHistoriesByDate(Date date);
        public List<SalaryHistoryDTO> FindSalaryHistoriesByDate(int page, int limit, Date date);
    }
}
