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
    public class DistrictServiceImpl : DistrictService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public DistrictServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }
        public int CountAll()
        {
            return _humanManagerContext.Districts.Count();
        }

        public List<DistrictDTO> FindAll(int page, int limit)
        {
            List<DistrictDTO> dtos = new List<DistrictDTO>();
            List<DistrictEntity> entities = _humanManagerContext.Districts
                                            .Skip((page - 1) * limit)
                                            .Take(limit)
                                            .Include(p => p.Province).ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<DistrictDTO>(entity));
            });

            return dtos;
        }
    }
}
