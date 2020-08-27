using human_managerment_backend.Entities;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Utils
{
    public class SalaryUtil
    {
        public static double GetSalaryCoefficient(JobLevelEntity jobLevel, int level)
        {

            double salaryCoefficient = 0;

            var listOfFieldNames = typeof(JobLevelEntity)//
                                        .GetProperties().Select(f => f.Name).ToList();

            foreach (string salaryLevelName in listOfFieldNames)
            {
                if (salaryLevelName.Equals(SystemContant.JOB_LEVEL_NAME_PREFIX + level))
                {
                    salaryCoefficient = (double)typeof(JobLevelEntity).GetProperty(salaryLevelName).GetValue(jobLevel);
                }
            }

            return salaryCoefficient;
        }

        public static double CountTotalInsurranceRatio(List<InsurranceEntity> insurrances)
        {
            double result = 0;
            try
            {
                foreach (InsurranceEntity ele in insurrances)
                {
                    result += ele.Ratio;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public static int DoRewardMoneyCounting(List<RewardPunishEntity> rewardPunishes)
        {
            int result = 0;
            try
            {
                foreach (var ele in rewardPunishes)
                {
                    if (ele.IsReward)
                        result += ele.Money;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public static int DoPublishMoneyCounting(List<RewardPunishEntity> rewardPunishes)
        {
            int result = 0;
            try
            {
                foreach (var ele in rewardPunishes)
                {
                    if (!ele.IsReward)
                        result += ele.Money;
                }
                return result;
            }
            catch
            {
                return result;
            }
        }

        public static SalaryHistoryEntity DoSalaryConting(EmployeeEntity employeeEntity, DateTime contingDate,int miniumSalary, double salaryCoefficient, int regulationWorkDay, int workDay, int rewardMoney, int publishMoney, double totalInsurranceRatio, List<TaxEntity> taxs)
        {
            int grossSalary = (int)((miniumSalary * salaryCoefficient) * ((double)workDay / regulationWorkDay));
            int insurranceMoney = (int)(grossSalary * totalInsurranceRatio / 100);
            int netSalary = grossSalary - insurranceMoney + rewardMoney - publishMoney;
            int taxMoney = DoTaxCounting(netSalary, taxs);
            netSalary = netSalary - taxMoney;
            return new SalaryHistoryEntity(contingDate, workDay, salaryCoefficient, taxMoney, rewardMoney, publishMoney, insurranceMoney, grossSalary, netSalary, employeeEntity);
        }

        private static int DoTaxCounting(int netSalary, List<TaxEntity> taxs)
        {
            int taxMoney = 0;
            foreach (TaxEntity tax in taxs)
            {
                if (tax.FromSalary < netSalary && netSalary <= tax.ToSalary)
                {
                    taxMoney = (int)(netSalary * tax.Ratio / 100);
                    break;
                }
                else
                    continue;

            }
            return taxMoney;
        }
    }
}

//(int)(basicSalary * taxRatio / 100)
