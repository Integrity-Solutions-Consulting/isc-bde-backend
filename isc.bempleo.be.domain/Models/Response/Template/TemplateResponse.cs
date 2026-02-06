using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Booklets
{
    public record class TemplateResponse
    {
        public int TemplateID { get; set; }
        public string message { get; set; }

    }
}
