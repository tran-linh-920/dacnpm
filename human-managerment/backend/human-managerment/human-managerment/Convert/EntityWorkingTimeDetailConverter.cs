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
    public class EntityWorkingTimeDetailConverter : ITypeConverter<WorkingTimeDetailEntity, WorkingTimeDetailDTO>
    {
        public WorkingTimeDetailDTO Convert(WorkingTimeDetailEntity source, WorkingTimeDetailDTO destination, ResolutionContext context)
        {
            destination = new WorkingTimeDetailDTO();

            if (source.WorkingTimeId > 0)
            {
                destination.WorkingTimeId =  source.WorkingTimeId;
            }

            if (source.TimeSlotId > 0)
            {
                destination.TimeSlotId = source.TimeSlotId;
            }

            if (source.WorkingTime != null)
            {
                destination.WorkingTime = new WorkingTimeDTO();

                destination.WorkingTime.Id = source.WorkingTime.Id;
                destination.WorkingTime.Name = source.WorkingTime.Name;
                destination.WorkingTime.Bio = source.WorkingTime.Bio;
            }

            if (source.TimeSlot != null) {
                destination.TimeSlot = new TimeSlotDTO();

                destination.TimeSlot.Id = source.TimeSlot.Id;
                destination.TimeSlot.Name = source.TimeSlot.Name;
                destination.TimeSlot.Bio = source.TimeSlot.Bio;
                destination.TimeSlot.Period = source.TimeSlot.Period;
            }

            return destination;
        }
    }
}
