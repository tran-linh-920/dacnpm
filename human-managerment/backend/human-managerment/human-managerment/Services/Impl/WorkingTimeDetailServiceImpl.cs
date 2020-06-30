using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class WorkingTimeDetailServiceImpl : WorkingTimeDetailService
    {

        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public WorkingTimeDetailServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }

        public WorkingTimeDetailDTO FindOne(long id)
        {
            throw new NotImplementedException();
        }

        public WorkingTimeDetailDTO Save(WorkingTimeDetailEntity entity)
        {
            return null;
        }
    }
}
