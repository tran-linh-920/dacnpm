using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class CandidateDTO
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageName { get; set; }
        public string Ethnic { get; set; }
        public string Hometown { get; set; }
        public string IDCard { get; set; }
        public string Degree { get; set; }
        public string Career { get; set; }
        public string Experience { get; set; }
        public string Literacy { get; set; }
        public string Skill { get; set; }
        public string Hobby { get; set; }
        public string Position { get; set; }
        public int Status { get; set; }
        public long Note_Id { get; set; }

        [JsonIgnore]
        public NoteDTO Note { get; set; }

        [JsonIgnore]
        public ICollection<ScheduleDTO> Schedules { get; set; }
    }
}
