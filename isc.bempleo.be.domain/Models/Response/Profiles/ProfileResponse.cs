using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Profiles
{
    public class ProfileResponse
    {
        public int GenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentificationNumber { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? MaritalStatus { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? Nationality { get; set; }
        public string? DisabilityCard { get; set; }
        public string? EducationLevel { get; set; }
        public string? EducationStatus { get; set; }
        public string? Carrier { get; set; }
        public string? AcademicInstitution { get; set; }
        public string? CountryOfStudy { get; set; }
        public string? EnglishLevel { get; set; }
    }

    public class CapacityResponse
    {

    }
}
