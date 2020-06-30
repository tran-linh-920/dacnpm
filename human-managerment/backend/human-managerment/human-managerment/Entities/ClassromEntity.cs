using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{
    public class ClassromEntity
    {
        [Key, Column("id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("name", TypeName = "varchar(200)"), Required]
        public String Name { get; set; }

        public ICollection<StudentEntity> Students { get; set; }

    }
}
