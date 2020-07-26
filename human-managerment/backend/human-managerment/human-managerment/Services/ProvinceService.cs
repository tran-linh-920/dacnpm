using HumanManagermentBackend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface ProvinceService
    {
        public int CountAll();
        public List<ProvinceDTO> FindAll(int page, int limit);
    }
}
