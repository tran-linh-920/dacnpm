using AutoMapper;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class TimeKeepingServiceImpl : TimeKeepingService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public TimeKeepingServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;


        }

        public List<TimeKeepingDTO> FindAll()
        {
            List<TimeKeepingDTO> dtos = new List<TimeKeepingDTO>();
            List<TimeKeepingEntity> entities = _humanManagerContext.Timekeepings.Where(tk => tk.status == 1).ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<TimeKeepingDTO>(entity));
            });
            return dtos;
        }

        public TimeKeepingDTO Replace(TimeKeepingEntity oldTimeKeeping)
        {

            var transaction = _humanManagerContext.Database.BeginTransaction();
            TimeKeepingEntity oldEntity = null;
            try
            {
                oldEntity = _humanManagerContext.Timekeepings.Where(tk => tk.Id == oldTimeKeeping.Id).SingleOrDefault();
            }
            catch
            {
            }
            throw new NotImplementedException();
        }

        public List<TimeKeepingDTO> Save()
        {

            var transaction = _humanManagerContext.Database.BeginTransaction();

            //lấy ngày hiện tại trong máy
            DateTime nowDate = DateTime.Now;
            String date = nowDate.ToString("dd/MM/yyyy");

            List<EmployeeEntity> entities = _humanManagerContext.Employees.ToList();
            List<TimeKeepingDTO> listDTO = new List<TimeKeepingDTO>();
            entities.ForEach(entity =>
            {
                TimeKeepingEntity entityTimeKeeping = new TimeKeepingEntity();
                entityTimeKeeping.idEmployee = entity.Id;
                entityTimeKeeping.minimumTime = 6;
                entityTimeKeeping.status = 1;
                entityTimeKeeping.dateStart = date;

                entityTimeKeeping = _humanManagerContext.Timekeepings.Add(entityTimeKeeping).Entity;

                listDTO.Add(_mapper.Map<TimeKeepingDTO>(entityTimeKeeping));
                // dtos.Add(_mapper.Map<EmployeeDTO>(entity));
            });

            _humanManagerContext.SaveChanges();
            transaction.Commit();
            //



            return listDTO;

        }
    }
}
