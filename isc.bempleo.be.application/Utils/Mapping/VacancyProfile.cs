using AutoMapper;
using isc.bempleo.be.domain.Entity.Careers;
using isc.bempleo.be.domain.Entity.Vacancies;
using isc.bempleo.be.domain.Models.Response.Careers;
using isc.bempleo.be.domain.Models.Response.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class VacancyProfile : Profile
    {
        public VacancyProfile()
        {
            CreateMap<Vacancy, VacancyResponse>();
        }
    }
}
