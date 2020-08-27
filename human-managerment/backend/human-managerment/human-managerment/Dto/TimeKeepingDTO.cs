using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class TimeKeepingDTO
    {
        public long Id { get; set; }

        public int totalWorkTime { get; set; }

        public int minimumTime { get; set; }

        public int timeLate { get; set; }

        public int overTime { get; set; }

        public String note { get; set; }

        public String dateStart { get; set; }

        public String dateEnd { get; set; }

        public long idEmployee { get; set; }

        public string nameEmployee { get; set; }

        // trang thai hiện thị buổi sáng chiều
        public int morning { get; set; }

        public int afternoon { get; set; }

        public int workDay { get; set; }

        public int status { get; set; }
    }
}
