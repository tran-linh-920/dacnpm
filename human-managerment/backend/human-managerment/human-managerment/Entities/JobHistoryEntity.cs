using human_managerment_backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HumanManagermentBackend.Entities
{
    [Table("JobsHistorys")]
    public class JobHistoryEntity
    {
        [Column("jhEmp_id")]
        public long EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }

        [Column("jhJob_id")]
        public long JobId { get; set; }
        public JobEntity Job { get; set; }

        [Column("jhDep_id")]
        public long DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }

        [Column("jhStartDate", TypeName = "Date")]
        public DateTime? StartDate { get; set; }

        [Column("jhEndDate", TypeName = "Date")]
        public DateTime? EndDate { get; set; }

        public List<JobHistoryDetailEntity> JobHistoryDetails { get; set; }


    }
}
