using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Entities
{
    public class NoteEntity
    {
        public long Id { get; set; }
        public string Content { get; set; }

        [JsonIgnore]
        public CandidateEntity Candidate { get; set; }
    }
}
