using AutoMapper;
using isc.bempleo.be.domain.Entity.Experiences;
using isc.bempleo.be.domain.Models.Request.Experiences;
using isc.bempleo.be.domain.Models.Response.Experiences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class ExperienceProfile : Profile
    {
        public ExperienceProfile() 
        {
            CreateMap<Experience, ExperienceResponse>();
            CreateMap<ExperienceRequest, Experience>();
            CreateMap<ExperienceUpdateRequest, Experience>();

        }

    }
}
