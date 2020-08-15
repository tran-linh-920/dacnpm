using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface ScheduleService
    {
        public List<ScheduleDTO> FindAll();
        public ScheduleDTO FindOne(long id);

        public ScheduleDTO Save(ScheduleEntity schedule);
    }
}
