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
    public class ShiftServiceImpl : ShiftService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public ShiftServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper, WorkingTimeUpdater wtUpdater)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }

        public int CountAll()
        {
           return _humanManagerContext.Shifts.Count();
        }

        public List<ShiftDTO> FindAll(int page, int limit)
        {
            List<ShiftDTO> dtos = new List<ShiftDTO>();

            List<ShiftEntity> entities = _humanManagerContext.Shifts
                                            .Skip((page - 1) * limit)
                                            .Take(limit)
                                            .ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<ShiftDTO>(entity));
            });

            return dtos;
        }

        public ShiftDTO Save(ShiftEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            ShiftEntity entity = null;

            try
            {
                entity = _humanManagerContext.Shifts.Add(newEntity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();

                ShiftDTO dto = _mapper.Map<ShiftDTO>(entity);

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public ShiftDTO Replace(ShiftEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ShiftEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
