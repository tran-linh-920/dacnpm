using HumanManagermentBackend.Dto;
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
    }
}
