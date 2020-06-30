using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface WorkingTimeDetailService
    {
        public WorkingTimeDetailDTO FindOne(long id);
        public WorkingTimeDetailDTO Save(WorkingTimeDetailEntity entity);
    }
}
