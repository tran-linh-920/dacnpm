using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface WardService
    {
        public int CountAll();
        public List<WardDTO> FindAll(int page, int limit);

        public WardDTO Save(WardEntity ward);

        public WardDTO Edit(long id, WardEntity ward);
    }
}
