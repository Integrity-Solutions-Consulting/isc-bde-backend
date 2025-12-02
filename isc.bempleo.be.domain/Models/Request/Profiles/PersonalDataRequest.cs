using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Profiles
{
    public class PersonalDataRequest
    {
        public int GenderId { get; set; }
        public int? MaritalStatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentificationNumber { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? Nationality { get; set; }
        public string? DisabilityCard { get; set; }


    }
}
