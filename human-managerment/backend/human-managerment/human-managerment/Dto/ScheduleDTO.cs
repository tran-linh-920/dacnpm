using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class ScheduleDTO
    {
        public long Id { get; set; }
        public DateTime InterviewDate { get; set; }
        public long CanId { get; set; }
        public string CanName { get; set; }
        public CandidateDTO Candidate { get; set; }
    }
}
