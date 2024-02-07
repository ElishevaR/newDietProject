using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MyException:Exception
    {
        public int status { get; set; }
        public string nameTable { get; set; }
        public MyException(int status, string nameTable, string message) : base(message)
        {
            this.status = status;
            this.nameTable = nameTable;
        }
    }
}
