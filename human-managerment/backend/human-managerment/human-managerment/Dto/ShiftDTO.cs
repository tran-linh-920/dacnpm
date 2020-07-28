using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class ShiftDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string WorkStartTime { get; set; }
        public string WorkEndTime { get; set; }
        public string BreakStartTime { get; set; }
        public string BreakEndTime { get; set; }
        public double WorkingHoursNumber { get; set; }
        public double WorkingDaysNumber { get; set; }
    }
}
