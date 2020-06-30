using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace human_managerment_backend.Dto
{
    public class TimeSlotDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public String Bio { get; set; }

        public String Period { get; set; }

        public List<WorkingTimeDetailDTO> WorkingTimeDetails { get; set; }
    }
}
