using human_managerment_backend.Entities;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Updaters
{
    public class JobUpdater
    {
        private readonly HumanManagerContext _humanManagerContext;

        public JobUpdater(HumanManagerContext humanManagerContext)
        {
            _humanManagerContext = humanManagerContext;
        }

        public JobEntity DoUpdate(JobEntity oldEntity, JobEntity newEntity)
        {
            oldEntity.JobTitle = newEntity.JobTitle;
            //oldEntity.MaxSalary = newEntity.MaxSalary;
            //oldEntity.MinSalary = newEntity.MinSalary;

            var oldJhs = oldEntity.JobHistorys;
            var newJhs = newEntity.JobHistorys;

            // Nếu các phần tử trong mảng mới không có trong mảng cũ, thì thêm chúng vào mảng cũ
            for (int i = 0; i < newJhs.Count(); i++)
            {
                if (!isExitsElement(newJhs[i], oldJhs))
                    oldJhs = addNewElement(newJhs[i], oldJhs);
            }

            // Nếu các phần tử trong mảng cũ không nằm trong mảng mới, thì xóa chúng đi.
            // Lưu ý khi xóa đối tượng length bị giảm đi. 
            for (int i = 0; i < oldJhs.Count();)
            {
                if (!isExitsElement(oldJhs[i], newJhs))
                {
                    oldJhs = removeElement(oldJhs[i], oldJhs);
                    i = i > 0 ? --i : 0;
                }
                else
                    i++;
            }

            return oldEntity;
        }

        private bool isExitsElement(JobHistoryEntity jobHistoryEntity, List<JobHistoryEntity> jhs)
        {
            bool result = false;

            foreach (JobHistoryEntity jh in jhs)
            {
                if (jh.DepartmentId == jobHistoryEntity.DepartmentId)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private List<JobHistoryEntity> addNewElement(JobHistoryEntity newElement, List<JobHistoryEntity> oldJhs)
        {
            oldJhs.Add(newElement);
            return oldJhs;
        }

        private List<JobHistoryEntity> removeElement(JobHistoryEntity oldElement, List<JobHistoryEntity> oldJhs)
        {
            foreach (JobHistoryEntity oldJh in oldJhs)
            {
                if (oldJh.DepartmentId == oldElement.DepartmentId)
                {
                    oldJhs.Remove(oldElement);
                    break;
                }
            }
            return oldJhs;
        }
    }
}
