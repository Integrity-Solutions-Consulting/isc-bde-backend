using isc.bempleo.be.domain.Entity.ProfileVacancies;
using isc.bempleo.be.domain.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Entity.ApplicationStatus
{
    public class ApplicationStatu : BaseEntity
    {
        public string StatusName { get; set; } 

        public ICollection<ProfileVacancy> ProfileVacancies { get; set; } = new List<ProfileVacancy>();
    }
}
