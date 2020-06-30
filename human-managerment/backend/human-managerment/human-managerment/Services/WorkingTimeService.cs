using human_managerment_backend.Entities;
using HumanManagermentBackend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface WorkingTimeService
    {
        public List<WorkingTimeDTO> FindAll();

        public WorkingTimeDTO Save(WorkingTimeEntity entity);

        public WorkingTimeDTO Replace(WorkingTimeEntity entity);

        bool Delete(WorkingTimeEntity newEntity);
    }
}
