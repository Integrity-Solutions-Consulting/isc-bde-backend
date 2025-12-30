using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Catalogs
{
    public class VacancyResponse
    {
        public string VacancyTitle { get; set; }
        public string PositionDescription { get; set; }
        public string? Requirements { get; set; }
        public DateTime? TerminationDate { get; set; }

    }
}
