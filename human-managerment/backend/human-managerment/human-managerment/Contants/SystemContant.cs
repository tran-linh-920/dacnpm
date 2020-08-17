using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Contants
{
    public class SystemContant
    {
        public const long Uploaded_File_Size_Limit = 100*1024*1024;

        public const string Uploading_Folder = "uploads";

        public const string Employee_Uploading_Path = "uploads/images/employees";

        public const string Candidate_Uploading_Path = "uploads/images/candidates";

        public const string Degrees_Uploading_Path = "uploads/images/degrees";


        public const string Uploaded_file_Prefix = "img";

        public const string JOB_LEVEL_NAME_PREFIX = "Level";

        public const string SALARY_COUNTING_SUCCSESS_MASSAGE = "Tính lương thành công.";

        public const string SALARY_COUNTING_FIELD_MASSAGE = "Không thể tính lương cho nhân viên.";

        public const string SALARY_COUNTING_FIELD_DETAIL_MASSAGE = "Không thể tính lương cho nhân viên: ";
    }
}
