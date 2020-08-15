using AutoMapper;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Convert
{
    public class EntityNoteConverter : ITypeConverter<NoteEntity, NoteDTO>
    {
        public NoteDTO Convert(NoteEntity source, NoteDTO destination, ResolutionContext context)
        {
            destination = new NoteDTO();
            if (source.Id > 0)
            {
                destination.Id = source.Id;
                destination.Content = source.Content;
            }
            return destination;
        }
    }
}
