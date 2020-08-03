using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class DepartmentDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public bool IsActive { get; set; }
        public List<JobHistoryDTO> JobHistorys { get; set; }
    }
}
