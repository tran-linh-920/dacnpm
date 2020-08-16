using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface DistrictService
    {
        public int CountAll();
        public List<DistrictDTO> FindAll(int page, int limit);

        public DistrictDTO Save(DistrictEntity district);
    }
}
