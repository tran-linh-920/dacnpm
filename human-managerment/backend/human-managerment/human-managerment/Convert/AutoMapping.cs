using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
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
            CreateMap<EmployeeEntity, EmployeeDTO>();
            CreateMap<EmployeeForm, EmployeeEntity>();

            CreateMap<ShiftEntity, ShiftDTO>();

            CreateMap<WorkingTimeEntity, WorkingTimeDTO>();
            CreateMap<WorkingTimeDetailEntity, WorkingTimeDetailDTO>().ConvertUsing<EntityWorkingTimeDetailConverter>();
            CreateMap<TimeSlotEntity, TimeSlotDTO>();
        }
    }


}
