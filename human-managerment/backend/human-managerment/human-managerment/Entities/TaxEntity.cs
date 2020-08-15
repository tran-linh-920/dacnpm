using human_managerment_backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("Taxs")]
    public class TaxEntity
    {
        [Key, Column("tax_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("taxDescribe", TypeName = "nvarchar(256)")]
        public string Describe { get; set; }

        [Column("taxFromSalary", TypeName = "int")]
        public int FromSalary { get; set; }

        [Column("taxToSalary", TypeName = "int")]
        public int ToSalary { get; set; }

        [Column("taxRatio", TypeName = "double")]
        public double Ratio { get; set; }
    }
}
