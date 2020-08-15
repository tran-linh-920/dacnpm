using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{

    [Table("Configures")]
    public class ConfigureEntity
    {
        [Key, Column("cfig_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("cfigRegulationWorkDay", TypeName = "int")]
        public int? RegulationWorkDay { get; set; }

        [Column("cfigMinimumSalary", TypeName= "int")]
        public int? MinimumSalary { get; set; }
    }
}
