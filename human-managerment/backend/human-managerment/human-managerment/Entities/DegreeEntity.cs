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
        [Column("dgName", TypeName = "varchar(200)"), Required]
        public String DegreeName { get; set; }
        [Column("dgBio", TypeName = "varchar(200)"), Required]
        public String DegreeBio { get; set; }

    }

}
