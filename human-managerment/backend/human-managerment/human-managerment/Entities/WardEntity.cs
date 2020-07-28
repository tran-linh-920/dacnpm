using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{
    [Table("Wards")]
    public class WardEntity
    {
        [Key, Column("w_id", TypeName = "bigint")]
        public long Id { get; set; }
        [Column("name", TypeName = "varchar(200)"), Required]
        public String Name { get; set; }

        [Column("distric_id", TypeName = "bigint"), Required]
        public long District_Id { get; set; }
        public DistrictEntity District { get; set; }

        public ICollection<AddressEntity> Addresses { get; set; }
    }
}
