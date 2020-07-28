using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class DistrictDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public long Province_Id { get; set; }
        public ProvinceDTO Province { get; set; }

        public ICollection<WardDTO> Wards { get; set; }

    }
}
