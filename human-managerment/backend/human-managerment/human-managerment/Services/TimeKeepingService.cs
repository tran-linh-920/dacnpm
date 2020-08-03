using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    interface TimeKeepingService
    {
        public List<TimeKeepingDTO> FindAll();
        public List<TimeKeepingDTO> Save();
        public TimeKeepingDTO Replace(TimeKeepingEntity oldTimeKeeping);
    }
}
