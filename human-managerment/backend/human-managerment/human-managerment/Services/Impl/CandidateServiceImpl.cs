using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Forms;
using HumanManagermentBackend.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace HumanManagermentBackend.Services.Impl
{
    public class CandidateServiceImpl : CandidateService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;
        private readonly UploadUtil _uploadUtil;
        private IWebHostEnvironment _hostingEnvironment;
        private readonly NoteService _noteService;

        public CandidateServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper, UploadUtil uploadUtil, IWebHostEnvironment hostingEnvironment,
                                    NoteServiceImpl noteService)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
            _uploadUtil = uploadUtil;
            _hostingEnvironment = hostingEnvironment;
            _noteService = noteService;
        }

        public int CountAll()
        {
            return _humanManagerContext.Candidates.Count();
        }

        public List<CandidateDTO> FindAll(int page, int limit, int status)
        {
            List<CandidateDTO> dtos = new List<CandidateDTO>();
            List<CandidateEntity> entities = _humanManagerContext.Candidates.Where(t => t.Status == status)
                                            .Skip((page - 1) * limit)
                                            .Take(limit)
                                            .ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<CandidateDTO>(entity));
            });

            return dtos;
        }

        public CandidateDTO FindOne(long id)
        {
            CandidateDTO dto = new CandidateDTO();
            CandidateEntity entity = _humanManagerContext.Candidates.Find(id);
            dto = _mapper.Map<CandidateDTO>(entity);
            return dto;
        }

        public CandidateDTO Save(CandidateForm canForm)
        {
            CandidateEntity entity = null;
            NoteDTO note = new NoteDTO();
            note.Content = "";
            note.Id = 0;
            canForm.Note = note;
            note = _noteService.Save(_mapper.Map<NoteEntity>(canForm.Note));
            canForm.Note = note;
            var transaction = _humanManagerContext.Database.BeginTransaction();
            
            try
            {
                string folderName = SystemContant.Candidate_Uploading_Path;
                string uploadPath = _hostingEnvironment.ContentRootPath;
                string newPath = Path.Combine(uploadPath, folderName);
                UploadUtil.Uploader uploader = _uploadUtil.DoFileUploading(newPath, canForm.UploadedFile);
                CandidateEntity newEntity = _mapper.Map<CandidateEntity>(canForm);
                newEntity.ImageName = uploader.fileName;
                entity = _humanManagerContext.Candidates.Add(newEntity).Entity;
                _humanManagerContext.SaveChanges();

                transaction.Commit();
                CandidateDTO dto = _mapper.Map<CandidateDTO>(entity);
                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public CandidateDTO Replace(long id, int status)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            CandidateDTO oldEntity = null;

            try
            {
                CandidateEntity entity = _humanManagerContext.Candidates.SingleOrDefault(item => item.Id == id);
                if (entity != null)
                {
                    entity.Status = status;
                    _humanManagerContext.SaveChanges();
                }

                transaction.Commit();

                CandidateDTO dto = _mapper.Map<CandidateDTO>(entity);

                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public void Delete(long id)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            try
            {
                NoteEntity note = _humanManagerContext.Notes.SingleOrDefault(item => item.Id == id);
                CandidateEntity entity = _humanManagerContext.Candidates.SingleOrDefault(item => item.Id == id);
                if (entity != null)
                {
                    _humanManagerContext.Notes.Remove(note);
                    _humanManagerContext.Candidates.Remove(entity);
                    _humanManagerContext.SaveChanges();
                }

                transaction.Commit();

               
            }
            catch
            {
                transaction.Rollback();
            }
        }
    }
}
