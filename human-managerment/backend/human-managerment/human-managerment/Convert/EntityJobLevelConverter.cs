using AutoMapper;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Convert
{
    public class EntityJobLevelConverter : ITypeConverter<JobLevelEntity, JobLevelDTO>
    {
        public JobLevelDTO Convert(JobLevelEntity source, JobLevelDTO destination, ResolutionContext context)
        {
            destination = new JobLevelDTO();

            destination.Id = source.Id;
            destination.Level1 = source.Level1;
            destination.Level2 = source.Level2;
            destination.Level3 = source.Level3;
            destination.Level4 = source.Level4;
            destination.Level5 = source.Level5;
            destination.Level6 = source.Level6;
            destination.Level7 = source.Level7;
            destination.Level8 = source.Level8;
            destination.Level9 = source.Level9;

            return destination;
        }
    }
}
