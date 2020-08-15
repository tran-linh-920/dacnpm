using AutoMapper;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Convert
{
    public class CandidateFormConverter : ITypeConverter<CandidateForm, CandidateEntity>
    {
        public CandidateEntity Convert(CandidateForm source, CandidateEntity destination, ResolutionContext context)
        {
            destination = new CandidateEntity();

            destination.Firstname = source.Firstname;
            destination.Lastname = source.Lastname;
            destination.BirthDay = source.BirthDay;
            destination.Email = source.Email;
            destination.PhoneNumber = source.PhoneNumber;
            destination.Literacy = source.Literacy;
            destination.Ethnic = source.Ethnic;
            destination.Degree = source.Degree;
            destination.Career = source.Career;
            destination.Experience = source.Experience;
            destination.Gender = source.Gender;
            destination.Hobby = source.Hobby;
            destination.Hometown = source.Hometown;
            destination.IDCard = source.IDCard;
            destination.ImageName = source.ImageName;
            destination.Skill = source.Skill;
            destination.Position = source.Position;
            destination.Status = source.Status;
            destination.Note_Id = source.Note.Id;
           
            

            return destination;
        }
    }
}
