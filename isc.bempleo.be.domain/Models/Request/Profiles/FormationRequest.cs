using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Profiles
{
    public class FormationRequest
    {
        public string? EducationLevel { get; set; }
        public string? EducationStatus { get; set; }
        public string? AcademicInstitution { get; set; }
        public string? CountryOfStudy { get; set; }
        public string? EnglishLevel { get; set; }
        public List<int> CareerIds { get; set; }

    }
}
