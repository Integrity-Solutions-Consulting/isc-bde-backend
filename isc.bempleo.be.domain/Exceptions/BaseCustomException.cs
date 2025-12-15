using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Exceptions
{
    public class BaseCustomException : Exception
    {
        public int Code { get; set; }

        public BaseCustomException(string message, int code = 500)
            : base(message)
        {
            Code = code;
        }

        public BaseCustomException(string message, int code, Exception innerException)
            : base(message, innerException)
        {
            Code = code;
        }
    }
}
