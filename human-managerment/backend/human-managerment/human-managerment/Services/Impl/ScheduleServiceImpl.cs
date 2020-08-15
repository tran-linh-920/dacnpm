using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using AutoMapper;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Forms;

namespace HumanManagermentBackend.Services.Impl
{
    public class ScheduleServiceImpl: ScheduleService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;
        public ScheduleServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
           
        }

        public List<ScheduleDTO> FindAll()
        {
            List<ScheduleDTO> dtos = new List<ScheduleDTO>();
            List<ScheduleEntity> entities = _humanManagerContext.Schedules
                                            .ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<ScheduleDTO>(entity));
            });

            return dtos;
        }

        public ScheduleDTO FindOne(long id)
        {
            ScheduleDTO dto = new ScheduleDTO();
            ScheduleEntity entity = _humanManagerContext.Schedules.Find(id);
            dto = _mapper.Map<ScheduleDTO>(entity);
            return dto;
        }

        public ScheduleDTO Save(ScheduleEntity schedule)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            ScheduleEntity entity = null;
            try
            {
                entity = _humanManagerContext.Schedules.Add(schedule).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();

                ScheduleDTO dto = _mapper.Map<ScheduleDTO>(entity);
                transaction.Dispose();

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }
    }
}
