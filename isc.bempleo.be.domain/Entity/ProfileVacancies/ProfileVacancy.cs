using isc.bempleo.be.domain.Entity.Catalogs;
using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Entity.ProfileVacancies
{
    public class ProfileVacancy : BaseEntity
    {
        public int ProfileId { get; set; }                 
        public int VacancyId { get; set; }                
        public DateTime ApplicationDate { get; set; }      
        public int ApplicationStatusId { get; set; }       
        public Profile Profile { get; set; }
        public Vacancy Vacancy { get; set; }
        public ApplicationStatu ApplicationStatus { get; set; }
    }
}
