using AutoMapper;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Updaters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class WorkingTimeServiceImpl : WorkingTimeService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;
        private readonly WorkingTimeUpdater _wtUpdater;

        public WorkingTimeServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper, WorkingTimeUpdater wtUpdater)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
            _wtUpdater = wtUpdater;
        }

        public List<WorkingTimeDTO> FindAll()
        {
            List<WorkingTimeDTO> dtos = new List<WorkingTimeDTO>();

            List<WorkingTimeEntity> entities = _humanManagerContext.WorkingTimes
                                            .Include(wt => wt.WorkingTimeDetails)
                                            .ThenInclude(wtd => wtd.TimeSlot).ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<WorkingTimeDTO>(entity));
            });

            return dtos;
        }


        public WorkingTimeDTO Save(WorkingTimeEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            WorkingTimeEntity entity = null;

            try
            {
                entity = _humanManagerContext.WorkingTimes.Add(newEntity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();

                WorkingTimeDTO dto = _mapper.Map<WorkingTimeDTO>(entity);

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public WorkingTimeDTO Replace(WorkingTimeEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            WorkingTimeEntity oldEntity = null;

            try
            {
                oldEntity = _humanManagerContext.WorkingTimes.Where(wt => wt.Id == newEntity.Id)
                                                             .Include(wt => wt.WorkingTimeDetails)
                                                             .SingleOrDefault();

                oldEntity = _wtUpdater.DoUpdate(oldEntity, newEntity);

                _humanManagerContext.SaveChanges();

                transaction.Commit();

                WorkingTimeDTO dto = _mapper.Map<WorkingTimeDTO>(oldEntity);

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public bool Delete(WorkingTimeEntity newEntity) {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            WorkingTimeEntity entity = null;

            try
            {
                entity = _humanManagerContext.WorkingTimes.Where(wt => wt.Id == newEntity.Id)
                                                             .Include(wt => wt.WorkingTimeDetails)
                                                             .SingleOrDefault();

                _humanManagerContext.Remove(entity);

                _humanManagerContext.SaveChanges();

                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        } 
    }
}
