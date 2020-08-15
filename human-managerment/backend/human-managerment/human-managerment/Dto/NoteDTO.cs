using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HumanManagermentBackend.Entities;
using System.Text.Json.Serialization;

namespace HumanManagermentBackend.Dto
{
    [Table("Notes")]
    public class NoteDTO
    {
        [Key, Column("note_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("content", TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }

        [JsonIgnore]
        public CandidateDTO Candidate { get; set; }
    }
}
