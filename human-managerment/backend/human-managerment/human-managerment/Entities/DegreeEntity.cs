using human_managerment_backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("degrees")]
    public class DegreeEntity
    {
        [Key, Column("dg_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("dgDegreeType_id", TypeName = "bigint")]
        public long DegreeTypeId { get; set; }
        public DegreeTypeEntity DegreeType { get; set; }

        [Column("dgEmp_id", TypeName = "bigint")]
        public long EmployeeId { get; set; } 
        public EmployeeEntity Employee { get; set; }

        [Column("dgImageName", TypeName = "varchar(128)")]
        public string ImageName { get; set; }

    }

}
