using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface IndentificationService
    {
        public List<IndentificationDTO> FindAll();
        public IndentificationDTO Save(IndentificationEntity entity);


    }
}
