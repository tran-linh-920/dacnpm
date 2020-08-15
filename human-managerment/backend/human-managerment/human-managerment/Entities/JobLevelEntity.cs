using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("JobLevels")]
    public class JobLevelEntity 
    {
        [Key, Column("jlv_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("jlvLevel1", TypeName = "double")]
        public double? Level1 { get; set; }

        [Column("jlvLevel2", TypeName = "double")]
        public double? Level2 { get; set; }

        [Column("jlvLevel3", TypeName = "double")]
        public double? Level3 { get; set; }

        [Column("jlvLevel4", TypeName = "double")]
        public double? Level4 { get; set; }

        [Column("jlvLevel5", TypeName = "double")]
        public double? Level5 { get; set; }

        [Column("jlvLevel6", TypeName = "double")]
        public double? Level6 { get; set; }

        [Column("jlvLevel7", TypeName = "double")]
        public double? Level7 { get; set; }

        [Column("jlvLevel8", TypeName = "double")]
        public double? Level8 { get; set; }

        [Column("jlvLevel9", TypeName = "int")]
        public double? Level9 { get; set; }

        [Column("jlvJob_id", TypeName = "bigint")]
        public long JobId { get; set; }

        public JobEntity Job { get; set; }
    }
}
