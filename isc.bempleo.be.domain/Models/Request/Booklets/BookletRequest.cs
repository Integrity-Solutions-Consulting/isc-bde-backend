using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Booklets
{
    public record class BookletRequest
    {
        public string BookletName { get; set; }
        public string Knowledge { get; set; }
        public string Tools { get; set; }
    }
}
