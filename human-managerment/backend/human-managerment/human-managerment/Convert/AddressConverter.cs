using AutoMapper;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Convert
{
    public class AddressConverter : ITypeConverter<AddressEntity, AddressDTO>
    {
        public AddressDTO Convert(AddressEntity source, AddressDTO destination, ResolutionContext context)
        {
            destination = new AddressDTO();
            if(source.Id > 0)
            {
                destination.Id = source.Id;
                destination.Name = source.Name;
                destination.Ward_Id = source.Ward_Id;

            }
            if (source.Ward != null)
            {
                destination.Ward = new WardDTO();
                destination.Ward.Id = source.Ward.Id;
                destination.Ward.Name = source.Ward.Name;
                destination.Ward.District_Id = source.Ward.District_Id;

                if (source.Ward.District != null)
                {
                    destination.Ward.District = new DistrictDTO();
                    destination.Ward.District.Id = source.Ward.District.Id;
                    destination.Ward.District.Name = source.Ward.District.Name;
                    destination.Ward.District.Province_Id = source.Ward.District.Province_Id;


                    if (source.Ward.District.Province != null)
                    {
                        destination.Ward.District.Province = new ProvinceDTO();
                        destination.Ward.District.Province.Id = source.Ward.District.Province.Id;
                        destination.Ward.District.Province.Name = source.Ward.District.Province.Name;

                    }
                }
            }
            return destination;
            
        }
    }
}
