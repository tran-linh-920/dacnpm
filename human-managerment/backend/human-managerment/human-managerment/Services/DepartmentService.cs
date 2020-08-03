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

    public interface DepartmentService
    {
        public int CountAll();
        public List<DepartmentDTO> FindAll(int page, int limit);
        public DepartmentDTO Save(DepartmentEntity entity);
        
    }
}
