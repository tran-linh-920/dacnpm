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
    public class AddressServiceImpl : AddressService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public AddressServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }
        public int CountAll()
        {
            return _humanManagerContext.Addresses.Count();
        }

        public List<AddressDTO> FindAll(int page, int limit)
        {
            List<AddressDTO> dtos = new List<AddressDTO>();
            List<AddressEntity> entities = _humanManagerContext.Addresses
                                            .Skip((page - 1) * limit)
                                            .Take(limit)
                                            .Include(w => w.Ward)
                                            .ThenInclude(d => d.District)
                                            .ThenInclude(p => p.Province).ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<AddressDTO>(entity));
            });

            return dtos;
        }
    }
}
