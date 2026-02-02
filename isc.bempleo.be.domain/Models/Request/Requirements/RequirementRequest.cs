using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Requirements
{
    public class RequirementRequest
    {
        public int ContactId { get; set; }
        public int ClientId { get; set; }
        public int WorkModeId { get; set; }
        public int CareerId { get; set; }
        public int VacancyId { get; set; }
        public int WorkCityId { get; set; }
        public int? TemplateId { get; set; }
        public int? CertificationId { get; set; }
        public string ContractPeriod { get; set; }
        public decimal Budget { get; set; }
        public string WorkingHours { get; set; }
        public int YearsExperience { get; set; } 
        public string OtherKnowledge { get; set; }
        public string AdditionalComments { get; set; }
    }
}
