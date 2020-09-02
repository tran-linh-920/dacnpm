using human_managerment_backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    [Table("logs")]
    public class LogEntity
    {
        [Key, Column("log_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("logMessage", TypeName = "nvarchar(256)"), Required]
        public string Message { get; set; }

        [Column("logLevel", TypeName = "nvarchar(128)"), Required]
        public string Level { get; set; }

        [Column("logAddress", TypeName = "nvarchar(500)"), Required]
        public string Address { get; set; }

        [Column("logIp", TypeName = "varchar(100)"), Required]
        public string Ip { get; set; }

        [Column("logCreatedAt", TypeName = "datetime"), Required]
        public DateTime CreatedAt { get; set; }

        [Column("user_id")]
        public long UserID { get; set; }
        public UserEntity User { get; set; }
    }
}
