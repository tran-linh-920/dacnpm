using HumanManagermentBackend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace human_managerment_backend.Dto
{
    public class WorkingTimeDetailDTO
    {
        public long WorkingTimeId { get; set; }
        public WorkingTimeDTO WorkingTime { get; set; }
        public long TimeSlotId { get; set; }
        public TimeSlotDTO TimeSlot { get; set; }

        public static implicit operator List<object>(WorkingTimeDetailDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
