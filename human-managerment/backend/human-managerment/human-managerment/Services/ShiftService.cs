
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System.Collections.Generic;

namespace HumanManagermentBackend.Services
{
    public interface ShiftService
    {
        public int CountAll();
        public List<ShiftDTO> FindAll(int page, int limit);
        public ShiftDTO Save(ShiftEntity entity);
        public ShiftDTO Replace(ShiftEntity entity);
        public bool Delete(ShiftEntity newEntity);
    }
}
