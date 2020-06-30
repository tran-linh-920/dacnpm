using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Models
{
    public class Api<T>
    {
        public int statusCode { get; set; }
        public T data { get; set; }
        public String massage { get; set; }

        public Api()
        {
        }

        public Api(int statusCode, T data, string massage)
        {
            this.statusCode = statusCode;
            this.data = data;
            this.massage = massage;
        }
    }
}
