using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("indentifications")]
    public class IndentificationEntity
    {
        [Key, Column("ind_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column("indName", TypeName = "varchar(200)"), Required]
        public String IndentificationName { get; set; }
        [Column("indBio", TypeName = "varchar(200)"), Required]
        public String IndentificationBio { get; set; }



    }
}
