using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("DegreeTypes")]
    public class DegreeTypeEntity
    {
        [Key, Column("dt_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("dtName", TypeName = "nvarchar(128)"), Required]
        public string Name { get; set; }

        [Column("dtBio", TypeName = "nvarchar(256)")]
        public string? DegreeBio { get; set; }

        public List<DegreeEntity> Degrees { get; set; }
    }

}
