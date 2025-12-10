using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Entity.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Documents
{
    public class DocumentRequest 
    {
        public string DocumentName { get; set; }
        public int ProfileId { get; set; }

    }
}
