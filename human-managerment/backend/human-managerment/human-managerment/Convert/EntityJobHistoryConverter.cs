using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Convert
{
    public class EntityJobHistoryConverter : ITypeConverter<JobHistoryEntity, JobHistoryDTO>
    {
        public JobHistoryDTO Convert(JobHistoryEntity source, JobHistoryDTO destination, ResolutionContext context)
        {
            destination = new JobHistoryDTO();

            if (source.JobId > 0)
            {
                destination.JobId = source.JobId;
            }

            if (source.DepartmentId > 0)
            {
                destination.DepartmentId = source.DepartmentId;
            }

            if (source.Job != null)
            {
                destination.Job = new JobDTO();

                destination.Job.Id = source.Job.Id;
                destination.Job.JobTitle = source.Job.JobTitle;
                destination.Job.MinSalary = source.Job.MinSalary;
                destination.Job.MaxSalary = source.Job.MaxSalary;
            }

            if (source.Department != null)
            {
                destination.Department = new DepartmentDTO();

                destination.Department.Id = source.Department.Id;
                destination.Department.DepartmentName = source.Department.DepartmentName;

            }

            return destination;
        }
    }
}
