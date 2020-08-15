using human_managerment_backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{
    [Table("Jobs")]
    public class JobEntity
    {
        [Key, Column("job_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("jobTitle", TypeName = "nvarchar(256)"), Required]
        public string JobTitle { get; set; }

        [Column("jobBio", TypeName = "nvarchar(500)")]
        public string? JobBio { get; set; }

        //[Column("jobMinSalary", TypeName = "double"), Required]
        //public int MinSalary { get; set; }

        //[Column("jobMaxSalary", TypeName = "double"), Required]
        //public int MaxSalary { get; set; }

        public List<JobHistoryEntity> JobHistorys { get; set; }
        public  JobLevelEntity JobLevel { get; set; }
        public List<EmployeeEntity> Employees { get; set; }

    }
}
