using System;
using System.Collections.Generic;

namespace HumanManagermentBackend.Dto
{
    public class ClassromDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public ICollection<StudentDTO> Students { get; set; }

    }
}
