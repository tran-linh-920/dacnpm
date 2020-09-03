using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface LogService
    {
        public int CountAll();
        public List<LogDTO> FindAll(int page, int limit);
        public LogDTO Save(LogEntity entity);
    }
}
