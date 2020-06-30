using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{

    public class StudentEntity
    {
        [Key, Column("id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("name", TypeName = "varchar(200)"), Required]
        public String Name { get; set; }

        public ClassromEntity Classrom { get; set; }

        [Column("classrom_id")]
        public long ClassromId { get; set; }
    }
}
