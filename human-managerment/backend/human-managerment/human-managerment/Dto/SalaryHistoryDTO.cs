using human_managerment_backend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class SalaryHistoryDTO
    {
        public long Id { get; set; }
        public DateTime CountedDate { get; set; }
        public int WorkDay { get; set; }
        public double SalaryCoefficient { get; set; }
        public int TaxMoney { get; set; }
        public int RewardMoney { get; set; }
        public int PublishMoney { get; set; }
        public int InsurranceMoney { get; set; }
        public double Salary { get; set; }
        public bool IsActive { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}
