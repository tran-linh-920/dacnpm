using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class LogDTO
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Address { get; set; }
        public string Ip { get; set; }
        public DateTime CreatedAt { get; set; }

        public long UserID { get; set; }
        public UserDTO User { get; set; }
    }
}
