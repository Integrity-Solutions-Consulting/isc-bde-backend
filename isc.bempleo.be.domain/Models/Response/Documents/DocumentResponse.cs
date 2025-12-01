using isc.bempleo.be.domain.Entity.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Documents
{
    public class DocumentResponse
    {
        public int Id { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
        public string Bucket { get; set; }
        public string ObjectName { get; set; }
        public string DocumentName { get; set; }
    }
}
