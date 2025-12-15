using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Exceptions
{
    public class NotFoundException : BaseCustomException
    {
        private const int DefaultCode = 404;

        public NotFoundException(string entity)
            : base($"{entity} no fue encontrado", DefaultCode)
        {
        }
    }

}
