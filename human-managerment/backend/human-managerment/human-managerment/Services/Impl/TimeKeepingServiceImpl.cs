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
        // hien thi ca sang
        public List<TimeKeepingDTO> findMorning()
        {
            List<TimeKeepingDTO> dtos = new List<TimeKeepingDTO>();
            List<TimeKeepingEntity> entities = _humanManagerContext.Timekeepings.Where(tk => tk.status == 1 && tk.morning ==1).ToList();

            entities.ForEach(entity =>
            {
                TimeKeepingDTO dto = _mapper.Map<TimeKeepingDTO>(entity);
                EmployeeEntity emp = _humanManagerContext.Employees.Where(emp => emp.Id == dto.idEmployee).FirstOrDefault();
                dto.nameEmployee = emp.Lastname + " " + emp.Firstname;
                dtos.Add(dto);
               
            });
            return dtos;
        }
        // hien thi ca chieu
        public List<TimeKeepingDTO> findAfternoon()
        {
            List<TimeKeepingDTO> dtos = new List<TimeKeepingDTO>();
            List<TimeKeepingEntity> entities = _humanManagerContext.Timekeepings.Where(tk => tk.status == 1 && tk.afternoon == 1).ToList();

            entities.ForEach(entity =>
            {
                TimeKeepingDTO dto = _mapper.Map<TimeKeepingDTO>(entity);
                EmployeeEntity emp = _humanManagerContext.Employees.Where(emp => emp.Id == dto.idEmployee).FirstOrDefault();
                dto.nameEmployee = emp.Lastname + " " + emp.Firstname;
                dtos.Add(dto);

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
                entityTimeKeeping.morning = 1;
                entityTimeKeeping.afternoon = 1;
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

        public TimeKeepingDTO stardUp(TimeKeepingEntity entity,string shift)
        {
            TimeKeepingEntity oldEntity;

            oldEntity = _humanManagerContext.Timekeepings.Where(tk => tk.Id == entity.Id).SingleOrDefault();
            oldEntity.morning = 0;

            //craeat Timekeepingdetail với ngày giờ hiện tại và trạng thái 1 đagn chấm công
            DateTime nowDate = DateTime.Now;
            TimeKeepingDetailEntity tkdEntity = new TimeKeepingDetailEntity();
            if (string.Compare(shift, "morning",true)==0)
            {
                tkdEntity.shift = "morning" ;
                oldEntity.morning = 0;
            }
            if (string.Compare(shift, "afternoon", true) == 0)
            {
                tkdEntity.shift = "afternoon";
                oldEntity.afternoon = 0;
            }
            tkdEntity.timeStart = nowDate;
            tkdEntity.status = 1;
            tkdEntity.timeKeepingId = oldEntity.Id;
            tkdEntity.employeeId = oldEntity.idEmployee;

            _humanManagerContext.TimeKeepingDetails.Add(tkdEntity);
            _humanManagerContext.SaveChanges();

            return _mapper.Map<TimeKeepingDTO>(oldEntity);
        }

        public List<TimeKeepingDTO> RefetTimeKeeping()
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            List<TimeKeepingEntity> entities = _humanManagerContext.Timekeepings.ToList();
            List<TimeKeepingDetailEntity> entityTimeKeepingDetail = _humanManagerContext.TimeKeepingDetails.Where(tkd => tkd.status == 1).ToList();

            if(entityTimeKeepingDetail.Count <= 0 || entityTimeKeepingDetail == null)
            {
                List<TimeKeepingDTO> dtos = new List<TimeKeepingDTO>();
                entities.ForEach(entity =>
                {
                    entity.morning = 1;
                    entity.afternoon = 1;
                    dtos.Add(_mapper.Map<TimeKeepingDTO>(entity));
                });
                _humanManagerContext.SaveChanges();
                transaction.Commit();
                return dtos;
            }
            else
            {
                return null;
            }
           
           
        }

        public List<TimeKeepingDTO> CloseTimeKeeping()
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            
            try
            {
                List<TimeKeepingEntity> entities = _humanManagerContext.Timekeepings.ToList();
                List<TimeKeepingDTO> dtos = new List<TimeKeepingDTO>();
                entities.ForEach(entity =>
                {
                    
                    //tính số ngày làm việc
                    double workDay = (entity.totalWorkTime + entity.overTime -entity.timeLate) / entity.minimumTime;
                    double dayRest = workDay - (int)workDay;
                   
                    if(dayRest >= 0.5)
                    {
                        entity.workDay = (int)workDay + 1;
                    }
                    else
                    {
                        entity.workDay = (int)workDay;
                    }
                    entity.status = 0;
                    entity.morning = 0;
                    entity.afternoon = 0;
                    dtos.Add(_mapper.Map<TimeKeepingDTO>(entity));
                });
                transaction.Commit();
                _humanManagerContext.SaveChanges();
                return dtos;
            }
            catch
            {
                throw new NotImplementedException();
            }
        
           
           
        }

        public List<TimeKeepingDTO> findTimeKeepingClose()
        {
            List<TimeKeepingDTO> dtos = new List<TimeKeepingDTO>();
            List<TimeKeepingEntity> entities = _humanManagerContext.Timekeepings.Where(tk => tk.status ==0).ToList();

            entities.ForEach(entity =>
            {
                TimeKeepingDTO dto = _mapper.Map<TimeKeepingDTO>(entity);
                EmployeeEntity emp = _humanManagerContext.Employees.Where(emp => emp.Id == dto.idEmployee).FirstOrDefault();
                dto.nameEmployee = emp.Lastname + " " + emp.Firstname;
                dtos.Add(dto);

            });
            return dtos;
        }
    }
}
