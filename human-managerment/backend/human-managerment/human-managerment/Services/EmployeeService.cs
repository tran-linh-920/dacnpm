
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Dto;
using System.Collections.Generic;

namespace HumanManagermentBackend.Services
{
    public interface EmployeeService
    {
        public int CountAll();
        public List<EmployeeDTO> FindAll(int page, int limit);
        public EmployeeDTO Save(EmployeeEntity entity);
        public EmployeeDTO Save(EmployeeForm empForm);
        public EmployeeDTO Replace(EmployeeEntity entity);
        public bool Delete(EmployeeEntity newEntity);
        List<EmployeeDTO> FindWithJob(int page, int limit);
    }
}
