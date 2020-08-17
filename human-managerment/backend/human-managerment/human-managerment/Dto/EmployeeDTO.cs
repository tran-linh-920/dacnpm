
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace human_managerment_backend.Dto
{
    public class EmployeeDTO
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDay { get; set; }
        public int JobLevel { get; set; }
        public JobDTO Job { get; set; }
        public string ImageName { get; set; }
        public List<DegreeDTO> Degrees { get; set; }
    }
}
