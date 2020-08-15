using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Models
{
    public class Api<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public String Message { get; set; }
        public Paging Paging { get; set; }

        public Api()
        {
        }

        public Api(int statusCode, string massage)
        {
            this.StatusCode = statusCode;
            this.Message = massage;
        }

        public Api(int statusCode, T data, string massage)
        {
            this.StatusCode = statusCode;
            this.Data = data;
            this.Message = massage;
        }

        public Api(int statusCode, T data, string massage, Paging paging)
        {
            this.StatusCode = statusCode;
            this.Data = data;
            this.Message = massage;
            this.Paging = paging;
        }

        public string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
