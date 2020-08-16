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
    public class ProvinceServiceImpl : ProvinceService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public ProvinceServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }
        public List<ProvinceDTO> FindAll(int page, int limit)
        {
            List<ProvinceDTO> dtos = new List<ProvinceDTO>();
            List<ProvinceEntity> entities = _humanManagerContext.Provinces
                                            .Skip((page - 1) * limit)
                                            .Take(limit).ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<ProvinceDTO>(entity));
            });

            return dtos;
        }
        public int CountAll()
        {
            return _humanManagerContext.Provinces.Count();
        }

        public ProvinceDTO save(ProvinceEntity entity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            try
            {
                entity = _humanManagerContext.Provinces.Add(entity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();
                ProvinceDTO dto = _mapper.Map<ProvinceDTO>(entity);
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
