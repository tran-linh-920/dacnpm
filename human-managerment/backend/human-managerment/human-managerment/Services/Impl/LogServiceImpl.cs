using AutoMapper;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Updaters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class LogServiceImpl : LogService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;
        public LogServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper, WorkingTimeUpdater wtUpdater)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }
        public int CountAll()
        {
            return _humanManagerContext.Logs.Count();
        }

        public List<LogDTO> FindAll(int page, int limit)
        {
            List<LogDTO> dtos = new List<LogDTO>();
            List<LogEntity> entities = _humanManagerContext.Logs
                                            .Skip((page - 1) * limit)
                                            .Take(limit)
                                            .ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<LogDTO>(entity));
            });

            return dtos;
        }

        public LogDTO Save(LogEntity entity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            try
            {
                entity = _humanManagerContext.Logs.Add(entity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();
                LogDTO dto = _mapper.Map<LogDTO>(entity);
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
