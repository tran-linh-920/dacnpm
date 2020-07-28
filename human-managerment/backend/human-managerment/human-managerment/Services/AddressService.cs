using HumanManagermentBackend.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface AddressService
    {
        public int CountAll();
        public List<AddressDTO> FindAll(int page, int limit);
    }
}
