using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiWithDB.Convert
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<WorkingTimeEntity, WorkingTimeDTO>();
            CreateMap<WorkingTimeDetailEntity, WorkingTimeDetailDTO>().ConvertUsing<EntityWorkingTimeDetailConverter>();
            CreateMap<TimeSlotEntity, TimeSlotDTO>();
        }
    }


}
