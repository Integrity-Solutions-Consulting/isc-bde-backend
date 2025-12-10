using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Entity.Documents
{
    public class Document : BaseEntity
    {
        public int ProfileId { get; set; }      
        public Profile Profile { get; set; }
        public string DocumentName { get; set; }

    }
}
