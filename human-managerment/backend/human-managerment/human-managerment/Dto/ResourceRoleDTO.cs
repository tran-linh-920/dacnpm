using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Dto
{
    public class ResourceRoleDTO
    {
        public ResourceDTO Resource { get; set; }
        // public RoleDTO Role { get; set; }
        public string? permissions { get; set; }
    }
}
