using AutoMapper;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Utils;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services.Impl
{
    public class SalaryServiceImpl : SalaryService
    {
        private readonly HumanManagerContext _humanManagerContext;
        private readonly IMapper _mapper;
        public SalaryServiceImpl(HumanManagerContext humanManagerContext, IMapper mapper)
        {
            _humanManagerContext = humanManagerContext;
            _mapper = mapper;
        }

        public bool CanCounting(DateTime countingDate)
        {
            // Kiêm tra ngày tính lương
            bool condition = _humanManagerContext.SalaryHistories.Where(sh => sh.CountedDate.Month != countingDate.Month && sh.CountedDate.Year == countingDate.Year).Any();
            if (condition)
                return true;
            return false;
        }
        public bool DoSalaryCounting()
        {
            throw new NotImplementedException();
        }

        public bool DoSalaryCounting(long empId)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            try
            {

                // Lấy cấu hình
                ConfigureEntity configure = _humanManagerContext.Configures.SingleOrDefault();

                // lấy nhân viên
                EmployeeEntity employeeEntity = _humanManagerContext.Employees
                                           .Where(e => e.Id == empId)
                                           .Include(e => e.Job)
                                           .ThenInclude(j => j.JobLevel)
                                           .Include(e => e.RewardPunishes)
                                           .SingleOrDefault();
                // Lấy bảo hiểm
                List<InsurranceEntity> insurrances = _humanManagerContext.Insurrances.ToList();

                // Lấy lương quy định tối thiểu
                int miniumSalary = (int)configure.MinimumSalary;

                // Tính hệ số lương
                double salaryCoefficient = SalaryUtil.GetSalaryCoefficient(employeeEntity.Job.JobLevel, employeeEntity.JobLevel);

                // Lây số ngày công quy định
                int regulationWorkDay = (int)configure.RegulationWorkDay;

                // Lấy số ngày công thực tế
                int empWorkDay = 30;

                // Lấy bảng thuế
                List<TaxEntity> taxs = _humanManagerContext.Taxs.ToList();

                // Tính phụ cấp


                // Tính thưởng phạt
                int rewardMoney = SalaryUtil.DoRewardMoneyCounting(employeeEntity.RewardPunishes);
                int publishMoney = SalaryUtil.DoPublishMoneyCounting(employeeEntity.RewardPunishes);

                // Tính bảo hiểm
                double totalInsurranceRatio = SalaryUtil.CountTotalInsurranceRatio(insurrances);

                // Tính lương
                SalaryHistoryEntity salaryHistoryEntity =//
                    SalaryUtil.DoSalaryConting(employeeEntity, miniumSalary, salaryCoefficient, regulationWorkDay, empWorkDay, rewardMoney, publishMoney, totalInsurranceRatio, taxs);

                // kiểm tra thay đổi lương
                SalaryHistoryEntity oldSalaryHistory = _humanManagerContext.SalaryHistories.Where(sh => sh.EmployeeId == employeeEntity.Id && sh.IsActive == true).SingleOrDefault();
                if (oldSalaryHistory == null || salaryHistoryEntity.Salary != oldSalaryHistory.Salary)
                {
                    // Chuyển trạng thái lương cũ
                    if (oldSalaryHistory != null)
                        oldSalaryHistory.IsActive = false;
                    // Lưu lương mới
                    salaryHistoryEntity = _humanManagerContext.SalaryHistories.Add(salaryHistoryEntity).Entity;
                    _humanManagerContext.SaveChanges();
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                    return false;
                }
                return true;

            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public JobHistoryDetailDTO DoSalaryIncreasing(long empId, int jobLevel)
        {
            var transaction = _humanManagerContext.Database.BeginTransaction();
            try
            {
                DateTime today = System.DateTime.Today;
                EmployeeEntity employeeEntity = _humanManagerContext.Employees.Where(e => e.Id == empId)
                                                      .Include(e => e.Job)
                                                      .ThenInclude(j => j.JobLevel)
                                                      .SingleOrDefault();

                JobHistoryEntity jobHistoryEntity = _humanManagerContext.JobHistorys.Where(jh => jh.EmployeeId == employeeEntity.Id && jh.JobId == employeeEntity.JobId).SingleOrDefault();

                // Kiểm tra việc tính lương. tính r ko đc nâng. 
                bool haveCounted = _humanManagerContext.SalaryHistories.Where(sh => sh.EmployeeId == empId && sh.CountedDate.Month == today.Month && sh.CountedDate.Year == today.Year).Any();
                if(haveCounted)
                    throw new Exception(SalaryMessageContant.SALARY_COUNTED);

                // kiểm tra và thay đổi job level
                JobLevelEntity jobLevelEntity = employeeEntity.Job.JobLevel;
                if (JobUtil.IsLevelExit(jobLevelEntity, jobLevel))
                    employeeEntity.JobLevel = jobLevel;
                else
                    throw new Exception(SalaryMessageContant.JOB_LEVEL_NOT_EXITS);

                // lưu level vào lịch sử
                _humanManagerContext.JobHistoryDetails.Add(new JobHistoryDetailEntity(jobLevel, today, jobHistoryEntity));
                _humanManagerContext.SaveChanges();

                transaction.Commit();

                return new JobHistoryDetailDTO(employeeEntity.Id, employeeEntity.Firstname + employeeEntity.Firstname, employeeEntity.JobId, employeeEntity.Job.JobTitle, jobLevel, System.DateTime.Today);

            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        int SalaryService.CountAllSalaryHistories()
        {
            return _humanManagerContext.SalaryHistories.Where(sh => sh.IsActive == true).Count();
        }

        List<SalaryHistoryDTO> SalaryService.FindSalaryHistories(int page, int limit)
        {
            List<SalaryHistoryDTO> dtos = new List<SalaryHistoryDTO>();

            List<SalaryHistoryEntity> entities = _humanManagerContext.SalaryHistories
                                            .Where(sh => sh.IsActive == true)
                                            .Include(sh => sh.Employee)
                                            .Skip((page - 1) * limit)
                                            .Take(limit).ToList();

            entities.ForEach(entity =>
            {
                dtos.Add(_mapper.Map<SalaryHistoryDTO>(entity));
            });

            return dtos;
        }
    }
}
