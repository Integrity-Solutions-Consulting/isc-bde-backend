using isc.bempleo.be.domain.Entity.ProfileVacancies;
using isc.bempleo.be.domain.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Entity.Vacancies
{
    public class Vacancy : BaseEntity
    {
        public string VacancyTitle { get; set; }   
        public string PositionDescription { get; set; }   
        public string? Requirements { get; set; }
        public DateTime? TerminationDate { get; set; } 
    }
}
