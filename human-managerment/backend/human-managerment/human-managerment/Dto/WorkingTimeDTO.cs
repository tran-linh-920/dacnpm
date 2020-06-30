using human_managerment_backend.Dto;
using System;
using System.Collections.Generic;

namespace HumanManagermentBackend.Dto
{
    public class WorkingTimeDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public String Bio { get; set; }

        public List<WorkingTimeDetailDTO> WorkingTimeDetails { get; set; }
    }
}