using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Booklets
{
    public record class BookletResponse
    {
        public string Knowledge { get; set; }
        public string Tools { get; set; }
    }
}
