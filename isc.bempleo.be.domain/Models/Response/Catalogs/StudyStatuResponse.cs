using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Catalogs
{
    public record StudyStatuResponse
    {
        public int EducationStatusID { get; set; }
        public string educationstatus_name { get; set; }

    }
}
