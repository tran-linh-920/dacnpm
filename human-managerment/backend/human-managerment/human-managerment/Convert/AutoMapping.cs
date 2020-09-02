using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Convert;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Forms;

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
            CreateMap<TimeKeepingDetailEntity , TimeKeepingDetailDTO>();

            CreateMap<DepartmentEntity, DepartmentDTO>();

            CreateMap<JobEntity, JobDTO>();
            CreateMap<JobHistoryEntity, JobHistoryDTO>().ConvertUsing<EntityJobHistoryConverter>();
            CreateMap<JobLevelEntity, JobLevelDTO>();

            CreateMap<DegreeForm, DegreeEntity>();
            CreateMap<DegreeEntity, DegreeDTO>();
            CreateMap<DegreeTypeEntity, DegreeTypeDTO>();
            CreateMap<IndentificationEntity, IndentificationDTO>();
            CreateMap<CandidateEntity, CandidateDTO>();
            //CreateMap<CandidateEntity, CandidateDTO>().ConvertUsing<EntityCandidateConverter>();
            CreateMap<CandidateForm, CandidateEntity>().ConvertUsing<CandidateFormConverter>();

            // CreateMap<NoteEntity, NoteDTO>().ConvertUsing<EntityNoteConverter>();
            CreateMap<NoteEntity, NoteDTO>();
            CreateMap<NoteDTO, NoteEntity>();
            CreateMap<ScheduleEntity, ScheduleDTO>();

            CreateMap<SalaryHistoryEntity, SalaryHistoryDTO>();

            CreateMap<UserEntity, UserDTO>();
            CreateMap<UserRoleEntity, UserRoleDTO>();
            CreateMap<RoleEntity, RoleDTO>();
            CreateMap<ResourceEntity, ResourceDTO>();
            CreateMap<ResourceRoleEntity, ResourceRoleDTO>();

            CreateMap<LogEntity, LogDTO>();
        }
    }


}
