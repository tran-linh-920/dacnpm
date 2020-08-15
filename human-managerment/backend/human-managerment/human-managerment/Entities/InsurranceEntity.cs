using human_managerment_backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("Insurrances")]
    public class InsurranceEntity
    {
        [Key, Column("ins_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("insName", TypeName = "nvarchar(256)"), Required]
        public string Name { get; set; }

        [Column("insRatio", TypeName = "double"), Required]
        public double Ratio { get; set; }
    }
}
