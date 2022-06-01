using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RHAuth.Utility
{
    public class OutputDTO<T>
    {
        public bool Succeeded { get; set; } = true;
        public int HttpStatusCode { get; set; } = 200;
        public string Message { get; set; } = "Success";
        public T Data { get; set; }
        public long TotalData { get; set; } = 0;
    }
}
