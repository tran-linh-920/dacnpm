using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HumanManagermentBackend.Entities
{
    public class ScheduleEntity
    {
        public long Id { get; set; }

        [Column("interview_date", TypeName = "datetime"), Required]
        public DateTime InterviewDate { get; set; }

        [Column("can_id", TypeName = "bigint")]
        public long CanId { get; set; }

        [Column("can_name", TypeName = "varchar(200)")]
        public string CanName { get; set; }

        [JsonIgnore]
        public CandidateEntity Candidate { get; set; }
    }
}
