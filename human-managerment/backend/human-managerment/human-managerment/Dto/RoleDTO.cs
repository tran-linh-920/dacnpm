using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class RoleDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

      //  public List<UserRoleDTO> UserRoles { get; set; }
        public List<ResourceRoleDTO> ResourceRoles { get; set; }
    }
}
