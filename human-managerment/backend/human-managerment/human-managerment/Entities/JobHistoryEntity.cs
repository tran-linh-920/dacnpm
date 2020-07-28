using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HumanManagermentBackend.Entities
{
    [Table("jobsHistorys")]
    public class JobHistoryEntity
    {
        [Column("htStartDate", TypeName = "Date"), Required]
        public DateTime StartDate { get; set; }
        [Column("htEndDate", TypeName = "Date"), Required]
        public DateTime EndDate { get; set; }
        public long JobId { get; set; }
        public JobEntity Job { get; set; }

        public long DepartmentId { get; set; }

        public DepartmentEntity Department { get; set; }


    }
}
