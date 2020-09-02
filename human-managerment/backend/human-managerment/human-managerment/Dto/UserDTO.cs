using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class UserDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public List<UserRoleDTO> UserRoles { get; set; }
        public List<LogDTO> Logs { get; set; }
    }
}
