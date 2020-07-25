using AutoMapper;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class EmployeeServiceImpl : EmployeeService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;
        private readonly UploadUtil _uploadUtil;
        private IWebHostEnvironment _hostingEnvironment;

        public EmployeeServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper, UploadUtil uploadUtil, IWebHostEnvironment hostingEnvironment)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
            _uploadUtil = uploadUtil;
            _hostingEnvironment = hostingEnvironment;
        }

        public int CountAll()
        {
            return _humanManagerContext.Employees.Count();
        }
        public List<EmployeeDTO> FindAll(int page, int limit)
        {
            List<EmployeeDTO> dtos = new List<EmployeeDTO>();

            List<EmployeeEntity> entities = _humanManagerContext.Employees
                                            .Skip((page - 1) * limit)
                                            .Take(limit).ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<EmployeeDTO>(entity));
            });

            return dtos;
        }

        public EmployeeDTO Save(EmployeeEntity entity)
        {
            throw new NotImplementedException();
        }

        public EmployeeDTO Save(EmployeeForm empForm)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            EmployeeEntity entity = null;

            try
            {
                string folderName = SystemContant.Employee_Uploading_Path;
                string uploadPath = _hostingEnvironment.ContentRootPath;
                string newPath = Path.Combine(uploadPath, folderName);
                UploadUtil.Uploader uploader = _uploadUtil.DoFileUploading(newPath, empForm.UploadedFile);

                EmployeeEntity newEntity = _mapper.Map<EmployeeEntity>(empForm);
                newEntity.ImageName = uploader.fileName;
                entity = _humanManagerContext.Employees.Add(newEntity).Entity;
                _humanManagerContext.SaveChanges();
                transaction.Commit();

                EmployeeDTO dto = _mapper.Map<EmployeeDTO>(entity);
                return dto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public bool Delete(EmployeeEntity newEntity)
        {
            throw new NotImplementedException();
        }

        public EmployeeDTO Replace(EmployeeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
