using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Convert;
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

            CreateMap<ProvinceEntity, ProvinceDTO>();
            CreateMap<DistrictEntity, DistrictDTO>().ConvertUsing<EntityDistrictConverter>();
            CreateMap<WardEntity, WardDTO>().ConvertUsing<EntityWardConverter>();
            CreateMap<AddressEntity, AddressDTO>().ConvertUsing<AddressConverter>();

            CreateMap<TimeKeepingEntity, TimeKeepingDTO>();

            CreateMap<DepartmentEntity, DepartmentDTO>();

            CreateMap<JobEntity, JobDTO>();
            CreateMap<JobHistoryEntity, JobHistoryDTO>().ConvertUsing<EntityJobHistoryConverter>();
            CreateMap<JobLevelEntity, JobLevelDTO>();

            CreateMap<DegreeEntity, DegreeDTO>();
            CreateMap<IndentificationEntity, IndentificationDTO>();

            CreateMap<SalaryHistoryEntity, SalaryHistoryDTO>();
        }
    }


}
