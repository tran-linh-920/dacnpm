using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
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

        public ProvinceDTO save(ProvinceEntity entity);
    }
}
