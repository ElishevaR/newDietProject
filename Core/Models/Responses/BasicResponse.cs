using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Responses
{
    public class BasicResponse<T>
    {
        public bool succeed { get; set; }
        public string massege { get; set; }
        public BasicResponse() { succeed = false; }
        public T response { get; set; }
    }
}
