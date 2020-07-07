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
        public int CountAll();
        public List<WorkingTimeDTO> FindAll(int page, int limit);

        public WorkingTimeDTO Save(WorkingTimeEntity entity);

        public WorkingTimeDTO Replace(WorkingTimeEntity entity);

        bool Delete(WorkingTimeEntity newEntity);
    }
}
