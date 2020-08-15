using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace human_managerment_backend.Entities
{
    [Table("Employees")]
    public class EmployeeEntity
    {
        [Key, Column("emp_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("empFirstname", TypeName = "nvarchar(256)"), Required]
        public string Firstname { get; set; }

        [Column("empLastname", TypeName = "nvarchar(256)"), Required]
        public string Lastname { get; set; }

        [Column("empBirthDay", TypeName = "date"), Required]
        public DateTime BirthDay { get; set; }

        [Column("empGender", TypeName = "bit")]
        public bool? Gender { get; set; }

        [Column("empEmail", TypeName = "varchar(128)"), Required]
        public string Email { get; set; }

        [Column("empPhoneNumber", TypeName = "varchar(128)"), Required]
        public string PhoneNumber { get; set; }

        [Column("empHireDay", TypeName = "date"), Required]
        public DateTime HireDay { get; set; }

        [Column("empJobLevel", TypeName = "int"), Required]
        public int JobLevel { get; set; }

        [Column("empImageName", TypeName = "varchar(128)")]
        public string ImageName { get; set; }

        [Column("empJob_id", TypeName = "bigint")]
        public long JobId { get; set; }
        public JobEntity Job { get; set; }

        public List<JobHistoryEntity> JobHistorys { get; set; }

        public List<RewardPunishEntity> RewardPunishes { get; set; }

        public List<SalaryHistoryEntity> SalaryHistories { get; set; }
    }
}
