using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    interface TimeKeepingDetailService
    {
        public List<TimeKeepingDetailDTO> findAllMorning();
        public List<TimeKeepingDetailDTO> findAllAfteroon();
        public List<TimeKeepingDetailDTO> findAllHistory();
        public TimeKeepingDetailDTO endTimeKeepingforOneDay(TimeKeepingDetailEntity entity);
        public TimeKeepingDetailDTO removeTimeKeeping(long id);
    }
}
