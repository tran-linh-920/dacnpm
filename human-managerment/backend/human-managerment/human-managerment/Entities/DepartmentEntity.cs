using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{

    [Table("departments")]
    public class DepartmentEntity
    {
        [Key, Column("d_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column("dName", TypeName = "nvarchar(256)"), Required]
        public String DepartmentName { get; set; }
        public List<JobHistoryEntity> JobHistorys { get; set; }


    }
}
