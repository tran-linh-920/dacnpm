using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set;}
        public string Message { get; set; }

        public CustomException(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }
    }
}
