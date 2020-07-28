using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HumanManagermentBackend.Convert
{
    public class EntityWardConverter : ITypeConverter<WardEntity, WardDTO>
    {
        public WardDTO Convert(WardEntity source, WardDTO destination, ResolutionContext context)
        {
            destination = new WardDTO();
            if (source.Id > 0)
            {
                destination.Id = source.Id;
                destination.Name = source.Name;
                destination.District_Id = source.District_Id;
                if (source.District != null)
                {
                    destination.District = new DistrictDTO();
                    destination.District.Id = source.District.Id;
                    destination.District.Name = source.District.Name;
                    destination.District.Province_Id = source.District.Province_Id;
                    if (source.District.Province != null)
                    {
                        destination.District.Province = new ProvinceDTO();
                        destination.District.Province.Id = source.District.Province.Id;
                        destination.District.Province.Name = source.District.Province.Name;
                    }


                }
            }
            return destination;
        }
    }
}
