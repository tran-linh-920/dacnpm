using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{
    [Table("Districts")]
    public class DistrictEntity
    {
        [Key, Column("d_id", TypeName = "bigint")]
        public long Id { get; set; }
        [Column("name", TypeName = "varchar(200)"), Required]
        public String Name { get; set; }

        [Column("province_id", TypeName = "bigint"), Required]
        public long Province_Id { get; set; }
        public ProvinceEntity Province { get; set; }
        public ICollection<WardEntity> Wards { get; set; }
    }
}
