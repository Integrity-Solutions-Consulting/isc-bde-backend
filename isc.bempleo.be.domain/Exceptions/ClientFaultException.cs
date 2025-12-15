using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Exceptions
{
    public class ClientFaultException : BaseCustomException
    {
        private const int DefaultCode = 400;

        public ClientFaultException(string message = "Check the request")
            : base(message, DefaultCode)
        {
        }

        public ClientFaultException(string message, Exception innerException)
            : base(message, DefaultCode, innerException)
        {
        }
    }

}
