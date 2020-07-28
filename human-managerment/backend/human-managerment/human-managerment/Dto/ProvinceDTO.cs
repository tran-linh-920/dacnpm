using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class ProvinceDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public ICollection<DistrictDTO> Districts { get; set; }
    }
}
