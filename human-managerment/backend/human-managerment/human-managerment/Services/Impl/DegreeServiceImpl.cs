using AutoMapper;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HumanManagermentBackend.Services.Impl
{
    public class DegreeServiceImpl: DegreeService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;


        public DegreeServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }

        public List<DegreeDTO> FindAll()
        {
            List<DegreeDTO> dtos = new List<DegreeDTO>();

            List<DegreeEntity> entities = _humanManagerContext.Degrees
                                           .ToList();


            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<DegreeDTO>(entity));
            });

            return dtos;
        }

        public DegreeDTO Save(DegreeEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            DegreeEntity entity = null;

            try
            {
                entity = _humanManagerContext.Degrees.Add(newEntity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();

                DegreeDTO dto = _mapper.Map<DegreeDTO>(entity);

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
