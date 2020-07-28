using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class AddressDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public long Ward_Id { get; set; }
        public WardDTO Ward { get; set; }

    }
}
