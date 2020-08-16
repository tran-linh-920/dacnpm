using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HumanManagermentBackend.Services.Impl
{
    public class WardServiceImpl: WardService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public WardServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }
        public int CountAll()
        {
            return _humanManagerContext.Wards.Count();
        }

        public WardDTO Edit(long id, WardEntity ward)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            try
            {
                WardEntity entity = _humanManagerContext.Wards.SingleOrDefault(item => item.Id == id);
                if (entity != null)
                {
                   // entity.Id = ward.Id;
                    entity.Name = ward.Name;
                    entity.District_Id = ward.District_Id;
                    _humanManagerContext.SaveChanges();
                }

                transaction.Commit();

                WardDTO dto = _mapper.Map<WardDTO>(entity);

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public List<WardDTO> FindAll(int page, int limit)
        {
            List<WardDTO> dtos = new List<WardDTO>();
            List<WardEntity> entities = _humanManagerContext.Wards
                                            .Skip((page - 1) * limit)
                                            .Take(limit)
                                            .Include(d => d.District)
                                            .ThenInclude(p => p.Province).ToList();
            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<WardDTO>(entity));
            });

            return dtos;
        }

        public WardDTO Save(WardEntity ward)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            try
            {
                ward = _humanManagerContext.Wards.Add(ward).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();
                WardDTO dto = _mapper.Map<WardDTO>(ward);
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
