using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Utils
{
    public class JobUtil
    {
        public static bool IsLevelExit(JobLevelEntity jobLevelEntity, int level)
        {

            try
            {
                double jobLevel = (double)typeof(JobLevelEntity).GetProperty(SystemContant.JOB_LEVEL_NAME_PREFIX + level).GetValue(jobLevelEntity);

                if (jobLevel == 0)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
