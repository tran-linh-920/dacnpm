using AutoMapper;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class IndentificationServiceImpl : IndentificationService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;


        public IndentificationServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }

        public List<IndentificationDTO> FindAll()
        {
            List<IndentificationDTO> dtos = new List<IndentificationDTO>();

            List<IndentificationEntity> entities = _humanManagerContext.Indentifications
                                           .ToList();


            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<IndentificationDTO>(entity));
            });

            return dtos;
        }

        public IndentificationDTO Save(IndentificationEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            IndentificationEntity entity = null;

            try
            {
                entity = _humanManagerContext.Indentifications.Add(newEntity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();

                IndentificationDTO dto = _mapper.Map<IndentificationDTO>(entity);

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
