using AutoMapper;
using isc.bempleo.be.domain.Entity.ApplicationStatus;
using isc.bempleo.be.domain.Entity.Vacancies;
using isc.bempleo.be.domain.Models.Response.ApplicationStatus;
using isc.bempleo.be.domain.Models.Response.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class ApplicationStatuProfile : Profile
    {
        public ApplicationStatuProfile()
        {
            CreateMap<ApplicationStatu, ApplicationStatuResponse>();
        }
    }
}
