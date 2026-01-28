using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Catalogs
{
    public record  class WorkCityResponse
    {
        public int WorkCityID { get; set; }

        public string workcity_name { get; set; }
    }
}
