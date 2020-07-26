using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{
    [Table("Addresses")]
    public class AddressEntity
    {
        [Key, Column("a_id", TypeName = "bigint")]
        public long Id { get; set; }
        [Column("name", TypeName = "varchar(200)"), Required]
        public String Name { get; set; }

        [Column("ward_id", TypeName = "bigint"), Required]
        public long Ward_Id { get; set; }
        public WardEntity Ward { get; set; }
    }
}
