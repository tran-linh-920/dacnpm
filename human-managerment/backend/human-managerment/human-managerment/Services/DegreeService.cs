using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HumanManagermentBackend.Services
{
    public interface DegreeService
    {
        public List<DegreeDTO> FindAll();
        public DegreeDTO Save(DegreeEntity entity);

    }
}
