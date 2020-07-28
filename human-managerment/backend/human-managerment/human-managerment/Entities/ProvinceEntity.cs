using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagermentBackend.Entities
{
    [Table("Provinces")]
    public class ProvinceEntity
    {
        [Key, Column("p_id", TypeName = "bigint")]
        public long Id { get; set; }
        [Column("name", TypeName = "varchar(200)"), Required]
        public String Name { get; set; }

        public ICollection<DistrictEntity> Districts { get; set; }
    }
}
