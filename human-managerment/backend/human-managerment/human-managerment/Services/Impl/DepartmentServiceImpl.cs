using AutoMapper;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Updaters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class DepartmentServiceImpl : DepartmentService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;


        public DepartmentServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }

        public List<DepartmentDTO> FindAll()
        {
            List<DepartmentDTO> dtos = new List<DepartmentDTO>();

            List<DepartmentEntity> entities = _humanManagerContext.Departments

                                           .ToList();


            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<DepartmentDTO>(entity));
            });

            return dtos;
        }


        public DepartmentDTO Save(DepartmentEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            DepartmentEntity entity = null;

            try
            {
                entity = _humanManagerContext.Departments.Add(newEntity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();

                DepartmentDTO dto = _mapper.Map<DepartmentDTO>(entity);

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;

            }
        }
    }
}
