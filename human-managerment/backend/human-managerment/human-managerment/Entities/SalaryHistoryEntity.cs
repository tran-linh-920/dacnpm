using human_managerment_backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("SalaryHistorys")]
    public class SalaryHistoryEntity
    {

        [Key, Column("sh_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("shCountedDate", TypeName = "date")]
        public DateTime CountedDate { get; set; }

        [Column("shWorkDay", TypeName = "int")]
        public int WorkDay { get; set; }

        [Column("shSalaryCoefficient", TypeName = "double")]
        public double SalaryCoefficient { get; set; }

        [Column("shTaxMoney", TypeName = "int")]
        public int TaxMoney { get; set; }
        
        [Column("shRewardMoney", TypeName = "int")]
        public int RewardMoney { get; set; }

        [Column("shPublishMoney", TypeName = "int")]
        public int PublishMoney { get; set; }

        [Column("shInsurranceMoney", TypeName = "int")]
        public int InsurranceMoney { get; set; }

        [Column("shSalary", TypeName = "double")]
        public double Salary { get; set; }

        [Column("shIsActive", TypeName = "bit")]
        public bool IsActive { get; set; }

        [Column("shEmp_Id", TypeName = "bigint")]
        public long EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }

        public SalaryHistoryEntity() { }
        public SalaryHistoryEntity(DateTime countedDate, int workDay, double salaryCoefficient, int taxMoney, int rewardMoney, int publishMoney, int insurranceMoney, double salary, EmployeeEntity employee)
        {
            CountedDate = countedDate;
            WorkDay = workDay;
            SalaryCoefficient = salaryCoefficient;
            TaxMoney = taxMoney;
            RewardMoney = rewardMoney;
            PublishMoney = publishMoney;
            InsurranceMoney = insurranceMoney;
            Salary = salary;
            Employee = employee;
            IsActive = true;
        }
    }
}
