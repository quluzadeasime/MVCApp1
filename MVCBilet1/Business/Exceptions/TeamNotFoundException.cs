using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class TeamNotFoundException : Exception
    {
        public string PropName { get; set; }
        public TeamNotFoundException(string propName,string? message) : base(message)
        {
            PropName = propName;
        }
    }
}
