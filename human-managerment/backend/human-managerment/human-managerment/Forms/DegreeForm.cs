using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Forms
{
    public class DegreeForm
    {
        public long EmployeeId { get; set; }
        public long DegreeTypeId { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
