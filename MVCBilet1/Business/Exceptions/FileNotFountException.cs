using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class FileNotFountException:Exception
    {
        public string PropName { get; set; }

        public FileNotFountException(string propname,string? message) : base(message)
        {
            PropName = propname;
        }


    }
}
