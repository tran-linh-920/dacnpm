using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{
    [Table("jobs")]
    public class JobEntity
    {
        [Key, Column("j_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column("jTitle", TypeName = "varchar(200)"), Required]
        public String JobTitle { get; set; }
        [Column("jMinSalary", TypeName = "double"), Required]
        public int MinSalary { get; set; }
        [Column("jMaxSalary", TypeName = "double"), Required]
        public int MaxSalary { get; set; }
        public List<JobHistoryEntity> JobHistorys { get; set; }

    }
}
