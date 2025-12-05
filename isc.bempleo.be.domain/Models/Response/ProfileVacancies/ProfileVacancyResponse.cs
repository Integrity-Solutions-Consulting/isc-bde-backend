using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.ProfileVacancies
{
    public class ProfileVacancyResponse
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int VacancyId { get; set; }
        public int ApplicationStatusId { get; set; }
        public DateTime ApplicationDate { get; set; }
        //public DateTime? TerminationDate { get; set; }
    }
}
