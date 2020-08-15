using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("JobsHistoryDetails")]
    public class JobHistoryDetailEntity
    {
        [Key, Column("jhd_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("jhdSalaryLevel", TypeName = "int"), Required]
        public int SalaryLevel { get; set; }

        [Column("jhdSalaryAssignDate", TypeName = "date"), Required]
        public DateTime SalaryAssignDate { get; set; }

        [Column("jhdJobHistory_id")]
        public long JobHistoryId { get; set; }
        public JobHistoryEntity JobHistory { get; set; }

        public JobHistoryDetailEntity() { }
        public JobHistoryDetailEntity( int salaryLevel, DateTime salaryAssignDate, JobHistoryEntity jobHistory)
        {
            SalaryLevel = salaryLevel;
            SalaryAssignDate = salaryAssignDate;
            JobHistory = jobHistory;
        }
    }
}
