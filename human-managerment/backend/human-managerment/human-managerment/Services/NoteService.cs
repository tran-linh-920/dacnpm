using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface NoteService
    {
        public int CountAll();
        public List<NoteDTO> FindAll(int page, int limit);
        public NoteDTO FindOne(long id);

        public NoteDTO Save(NoteEntity entity);

        public NoteDTO Replace(long id, NoteEntity entity);

        bool Delete(NoteEntity newEntity);
    }
}
