using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.ProfileVacancies
{
    public class ProfileVacancyRequest
    {
        public int ProfileId { get; set; }
        public int VacancyId { get; set; }
        public int? ApplicationStatusId { get; set; }
    }
}
