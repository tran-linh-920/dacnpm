using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class JobLevelDTO
    {
        public long Id { get; set; }
        public double? Level1 { get; set; }
        public double? Level2 { get; set; }

        public double? Level3 { get; set; }

        public double? Level4 { get; set; }

        public double? Level5 { get; set; }

        public double? Level6 { get; set; }

        public double? Level7 { get; set; }

        public double? Level8 { get; set; }

        public double? Level9 { get; set; }

        public JobDTO Job { get; set; }
    }
}
