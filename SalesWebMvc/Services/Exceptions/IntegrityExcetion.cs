using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services.Exceptions
{
    public class IntegrityExcetion : ApplicationException
    {

        public IntegrityExcetion(string message) :base(message)
        {

        }

    }
}
