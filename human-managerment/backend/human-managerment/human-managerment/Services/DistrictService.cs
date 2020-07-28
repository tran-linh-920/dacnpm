using HumanManagermentBackend.Dto;
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
    }
}
