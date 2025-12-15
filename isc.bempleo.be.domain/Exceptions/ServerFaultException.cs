using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Exceptions
{
    public class ServerFaultException : BaseCustomException
    {
        public ServerFaultException(string message = "Unexpected server error", int code = 500)
    : base(message, code)
        {
        }

        public ServerFaultException(string message, int code, Exception innerException)
            : base(message, code, innerException)
        {
        }
    }
}
