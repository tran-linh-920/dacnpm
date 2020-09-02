using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Contants
{
    public class SecurityContant
    {
        public const string ACTION_SEPARATOR = ";";
        public const string ACTION_REQUESTMETHOD_SEPARATOR = ":";
        public const string REQUESTMETHOD_SEPARATOR = ",";

        public const string USER_NAME_CLAIMS = "username";
        public const string USER_RESOURCE_CLAIMS = "userResources";

        public const string NOT_AUTHORIZE = "Người dùng không được phép thực hiện hành động này.";
    }
}
