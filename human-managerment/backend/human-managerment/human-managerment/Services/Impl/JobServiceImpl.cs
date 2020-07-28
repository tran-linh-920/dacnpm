using AutoMapper;
using human_managerment_backend.Dto;
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
    public class JobServiceImpl : JobService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;
        private readonly JobUpdater _jUpdater;

        public JobServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper, JobUpdater jUpdater)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
            _jUpdater = jUpdater;
        }

        public List<JobDTO> FindAll()
        {
            List<JobDTO> dtos = new List<JobDTO>();

            List<JobEntity> entities = _humanManagerContext.Jobs
                                            .Include(j => j.JobHistorys)
                                            .ThenInclude(jh => jh.Department).ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<JobDTO>(entity));
            });

            return dtos;
        }


        public JobDTO Save(JobEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            JobEntity entity = null;

            try
            {
                entity = _humanManagerContext.Jobs.Add(newEntity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();

                JobDTO dto = _mapper.Map<JobDTO>(entity);

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public JobDTO Replace(JobEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            JobEntity oldEntity = null;

            try
            {
                oldEntity = _humanManagerContext.Jobs.Where(j => j.Id == newEntity.Id)
                                                             .Include(j => j.JobHistorys)
                                                             .SingleOrDefault();

                oldEntity = _jUpdater.DoUpdate(oldEntity, newEntity);

                _humanManagerContext.SaveChanges();

                transaction.Commit();

                JobDTO dto = _mapper.Map<JobDTO>(oldEntity);

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public bool Delete(JobEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            JobEntity entity = null;

            try
            {
                entity = _humanManagerContext.Jobs.Where(j => j.Id == newEntity.Id)
                                                             .Include(j => j.JobHistorys)
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
