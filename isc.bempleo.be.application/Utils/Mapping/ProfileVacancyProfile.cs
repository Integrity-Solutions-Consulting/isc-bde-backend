using AutoMapper;
using isc.bempleo.be.domain.Entity.ProfileVacancies;
using isc.bempleo.be.domain.Models.Response.ProfileVacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class ProfileVacancyProfile : Profile
    {
        public ProfileVacancyProfile()
        {
            CreateMap<ProfileVacancy, ProfileVacancyResponse>();
        }
    }
}
