using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Contacts
{
    public record class ContactRequest
    {
        public string ContactName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
    }
}
