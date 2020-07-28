using AutoMapper;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Convert
{
    public class EntityDistrictConverter : ITypeConverter<DistrictEntity, DistrictDTO>
    {
        public DistrictDTO Convert(DistrictEntity source, DistrictDTO destination, ResolutionContext context)
        {
            destination = new DistrictDTO();
            if (source.Id > 0)
            {
                destination.Id = source.Id;
                destination.Name = source.Name;
                destination.Province_Id = source.Province_Id;
                if(source.Province != null)
                {
                    destination.Province = new ProvinceDTO();
                    destination.Province.Id = source.Province.Id;
                    destination.Province.Name = source.Province.Name;

                }
            }
            return destination;
        }
    }
}
