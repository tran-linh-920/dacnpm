using AutoMapper;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace HumanManagermentBackend.Convert
{
    public class EntityCandidateConverter : ITypeConverter<CandidateEntity, CandidateDTO>
    {
        public CandidateDTO Convert(CandidateEntity source, CandidateDTO destination, ResolutionContext context)
        {
            destination = new CandidateDTO();

            destination.Id = source.Id;
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
