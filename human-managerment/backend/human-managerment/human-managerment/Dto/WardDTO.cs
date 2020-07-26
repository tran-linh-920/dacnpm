using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class WardDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public long District_Id { get; set; }
        public DistrictDTO District { get; set; }

        public ICollection<AddressDTO> Addresses { get; set; }
    }
}
