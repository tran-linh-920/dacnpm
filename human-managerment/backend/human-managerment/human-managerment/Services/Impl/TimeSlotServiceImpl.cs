using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class TimeSlotServiceImpl : TimeSlotService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public TimeSlotServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }

        public List<TimeSlotDTO> FindAll()
        {
            List<TimeSlotDTO> dtos = new List<TimeSlotDTO>();

            List<TimeSlotEntity> entities = _humanManagerContext.TimeSlots.Include(ts => ts.WorkingTimeDetails)
                                                                          .ThenInclude(wtd => wtd.WorkingTime)
                                                                          .ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<TimeSlotDTO>(entity));
            });

            return dtos;
        }
    }
}
