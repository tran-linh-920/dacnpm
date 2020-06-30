using human_managerment_backend.Entities;
using HumanManagermentBackend.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Updaters
{
    public class WorkingTimeUpdater
    {
        private readonly HumanManagerContext _humanManagerContext;

        public WorkingTimeUpdater(HumanManagerContext humanManagerContext)
        {
            _humanManagerContext = humanManagerContext;
        }

        public WorkingTimeEntity DoUpdate(WorkingTimeEntity oldEntity, WorkingTimeEntity newEntity)
        {
            oldEntity.Name = newEntity.Name;
            oldEntity.Bio = newEntity.Bio;

            var oldWtds = oldEntity.WorkingTimeDetails;
            var newWtds = newEntity.WorkingTimeDetails;

            // Nếu các phần tử trong mảng mới không có trong mảng cũ, thì thêm chúng vào mảng cũ
            for (int i = 0; i < newWtds.Count(); i++)
            {
                if (!isExitsElement(newWtds[i], oldWtds))
                    oldWtds = addNewElement(newWtds[i], oldWtds);
            }

            // Nếu các phần tử trong mảng cũ không nằm trong mảng mới, thì xóa chúng đi.
            // Lưu ý khi xóa đối tượng length bị giảm đi. 
            for (int i = 0; i < oldWtds.Count(); )
            {
                if (!isExitsElement(oldWtds[i], newWtds))
                {
                    oldWtds = removeElement(oldWtds[i], oldWtds);
                    i = i > 0 ? --i : 0;
                }
                else 
                    i++;
            }

            return oldEntity;
        }

        private bool isExitsElement(WorkingTimeDetailEntity workingTimeDetailEntity, List<WorkingTimeDetailEntity> wtds)
        {
            bool result = false;

            foreach (WorkingTimeDetailEntity wtd in wtds)
            {
                if (wtd.TimeSlotId == workingTimeDetailEntity.TimeSlotId)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private List<WorkingTimeDetailEntity> addNewElement(WorkingTimeDetailEntity newElement, List<WorkingTimeDetailEntity> oldWtds)
        {
            oldWtds.Add(newElement);
            return oldWtds;
        }

        private List<WorkingTimeDetailEntity> removeElement(WorkingTimeDetailEntity oldElement, List<WorkingTimeDetailEntity> oldWtds)
        {
            foreach (WorkingTimeDetailEntity oldWtd in oldWtds)
            {
                if (oldWtd.TimeSlotId == oldElement.TimeSlotId)
                {
                    oldWtds.Remove(oldElement);
                    break;
                }
            }
            return oldWtds;
        }
    }
}
