using human_managerment_backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("RewardPunish")]
    public class RewardPunishEntity
    {
        [Key, Column("rp_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("rpReason", TypeName = "nvarchar(500)"), Required]
        public string Reason { get; set; }

        [Column("rpIsReward", TypeName = "bit"), Required]
        public bool IsReward { get; set; }

        [Column("rpMoney", TypeName = "int"), Required]
        public int Money { get; set; }

        [Column("rpEmp_id", TypeName = "bigint"), Required]
        public long EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }
    }
}
