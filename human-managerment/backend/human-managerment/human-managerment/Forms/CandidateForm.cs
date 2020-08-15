using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanManagermentBackend.Dto;

namespace HumanManagermentBackend.Forms
{
    public class CandidateForm
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageName { get; set; }
        public string Ethnic { get; set; }
        public string Hometown { get; set; }
        public string IDCard { get; set; }
        public string Degree { get; set; }
        public string Career { get; set; }
        public string Experience { get; set; }
        public string Literacy { get; set; }
        public string Skill { get; set; }
        public string Hobby { get; set; }
        public string Position { get; set; }
        public int Status { get; set; }
        public NoteDTO Note { get; set; }
        public IFormFile UploadedFile { get; set; }

    }
}
