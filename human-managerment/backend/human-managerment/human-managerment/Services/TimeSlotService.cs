using human_managerment_backend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface TimeSlotService
    {
        public List<TimeSlotDTO> FindAll();
    }
}
