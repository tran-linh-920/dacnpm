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
    public class NoteServiceImpl : NoteService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;
        public NoteServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper, WorkingTimeUpdater wtUpdater)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }
        public int CountAll()
        {
            return _humanManagerContext.Notes.Count();
        }

        public bool Delete(NoteEntity newEntity)
        {
            throw new NotImplementedException();
        }

        public List<NoteDTO> FindAll(int page, int limit)
        {
            throw new NotImplementedException();
        }

        public NoteDTO FindOne(long id)
        {
            NoteDTO dto = new NoteDTO();
            NoteEntity entity = _humanManagerContext.Notes.Find(id);
            dto = _mapper.Map<NoteDTO>(entity);
            return dto;
        }

        public NoteDTO Replace(long id, NoteEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            NoteEntity oldEntity = null;

            try
            {
                NoteEntity entity = _humanManagerContext.Notes.SingleOrDefault(item => item.Id == id);
                if(entity != null)
                {
                    entity.Id = newEntity.Id;
                    entity.Content = newEntity.Content;
                    _humanManagerContext.SaveChanges();
                }

                transaction.Commit();

                NoteDTO dto = _mapper.Map<NoteDTO>(entity);

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public NoteDTO Save(NoteEntity newEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            NoteEntity entity = null;
            try
            {
                entity = _humanManagerContext.Notes.Add(newEntity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();

                NoteDTO dto = _mapper.Map<NoteDTO>(entity);
                transaction.Dispose();

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
