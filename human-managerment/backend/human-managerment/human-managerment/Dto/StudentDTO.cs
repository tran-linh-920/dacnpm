using System;

namespace HumanManagermentBackend.Dto
{

    public class StudentDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public ClassromDTO Classrom { get; set; }
    }
}
