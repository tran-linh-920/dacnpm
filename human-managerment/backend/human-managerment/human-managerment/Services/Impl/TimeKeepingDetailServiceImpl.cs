using AutoMapper;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class TimeKeepingDetailServiceImpl : TimeKeepingDetailService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;

        public TimeKeepingDetailServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }
        public List<TimeKeepingDetailDTO> findAllAfteroon()
        {
            List<TimeKeepingDetailDTO> dtos = new List<TimeKeepingDetailDTO>();
            List<TimeKeepingDetailEntity> entities = _humanManagerContext.TimeKeepingDetails.Where(tkd => tkd.shift == "afternoon" && tkd.status == 1).ToList();
            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<TimeKeepingDetailDTO>(entity));
            });
            return dtos;
            throw new NotImplementedException();
        }

        public List<TimeKeepingDetailDTO> findAllHistory()
        {
            List<TimeKeepingDetailDTO> dtos = new List<TimeKeepingDetailDTO>();
            List<TimeKeepingDetailEntity> entities = _humanManagerContext.TimeKeepingDetails.Where(tkd =>tkd.status ==0)
                                            //.Skip((page - 1) * limit)
                                           // .Take(limit)
                                            .ToList();

            for(int i =entities.Count -1 ; i>=0; i--)
            {
                EmployeeEntity em = _humanManagerContext.Employees.Where(e =>e.Id == entities[i].employeeId).SingleOrDefault();
                entities[i].employeeName = em.Lastname +" "+ em.Firstname ;
                dtos.Add(_mapper.Map<TimeKeepingDetailDTO>(entities[i]));
            }
         
            return dtos;
        }

        public List<TimeKeepingDetailDTO> findAllMorning()
        {
            List<TimeKeepingDetailDTO> dtos = new List<TimeKeepingDetailDTO>();
            List<TimeKeepingDetailEntity> entities = _humanManagerContext.TimeKeepingDetails.Where(tkd => tkd.shift == "morning" && tkd.status==1).ToList();
            entities.ForEach(entity =>
            {
             //  EmployeeEntity employee = _humanManagerContext.Employees.Where(e => e.Id == entity.employeeId).FirstOrDefault();
                TimeKeepingDetailDTO tkdto = _mapper.Map<TimeKeepingDetailDTO>(entity);
                dtos.Add(tkdto);
            });
            return dtos;
        }
        // chức năng kết thúc ngày công
        public TimeKeepingDetailDTO endTimeKeepingforOneDay(TimeKeepingDetailEntity oldEntity)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            DateTime nowDate = DateTime.Now;
            //  DateTime endDate = new DateTime('8/11/2020 10:06:00 PM');
            try
            {
                TimeKeepingDetailEntity old = _humanManagerContext.TimeKeepingDetails.Where(tkd => tkd.Id == oldEntity.Id).SingleOrDefault();

                TimeKeepingEntity oldTimeKeeping = _humanManagerContext.Timekeepings.Where(tk => tk.Id == old.timeKeepingId).SingleOrDefault();
                String test = oldTimeKeeping.Id + "";
                DateTime oldDateTime = old.timeStart;
                TimeSpan t = nowDate - oldDateTime;
                int count = t.Hours;

                //Cộng thời gian làm lên
                oldTimeKeeping.plusWorkingTime(count);

                old.status = 0;
                old.timeEnd = nowDate;
                old.timeWorking = count;

                _humanManagerContext.SaveChanges();

                return _mapper.Map<TimeKeepingDetailDTO>(old);
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
         
        }

        public TimeKeepingDetailDTO removeTimeKeeping(long id)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            // lấy dữ liệu cũ
            TimeKeepingDetailEntity oldEntity=   _humanManagerContext.TimeKeepingDetails.Where(tkd =>tkd.Id ==id).SingleOrDefault();
            // remove add save ;
            try
            {
                _humanManagerContext.TimeKeepingDetails.Remove(oldEntity);
                transaction.Commit();
                _humanManagerContext.SaveChanges();
                return _mapper.Map<TimeKeepingDetailDTO>(oldEntity);
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
               
       
        }
    }
}
