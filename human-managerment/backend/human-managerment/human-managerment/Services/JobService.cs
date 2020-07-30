using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface JobService
    {
        public List<JobDTO> FindAll();
        public JobDTO Save(JobEntity entity);

        public JobDTO Replace(JobEntity entity);

        bool Delete(JobEntity newEntity);



    }
}
