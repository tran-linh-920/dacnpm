using AutoMapper;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Forms;
using HumanManagermentBackend.Utils;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HumanManagermentBackend.Services.Impl
{
    public class DegreeServiceImpl: DegreeService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;
        private readonly UploadUtil _uploadUtil;
        private IWebHostEnvironment _hostingEnvironment;

        public DegreeServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper, UploadUtil uploadUtil, IWebHostEnvironment hostingEnvironment)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
            _uploadUtil = uploadUtil;
            _hostingEnvironment = hostingEnvironment;
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

        public DegreeDTO Save(DegreeForm form)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            DegreeEntity entity = null;

            try
            {
                string folderName = SystemContant.Degrees_Uploading_Path;
                string uploadPath = _hostingEnvironment.ContentRootPath;
                string newPath = Path.Combine(uploadPath, folderName);
                UploadUtil.Uploader uploader = _uploadUtil.DoFileUploading(newPath, form.UploadedFile);

                DegreeEntity newEntity = _mapper.Map<DegreeEntity>(form);
                newEntity.ImageName = uploader.fileName;
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
