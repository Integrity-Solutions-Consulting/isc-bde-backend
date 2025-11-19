using AutoMapper;
using isc.bempleo.be.domain.Entity.Skills;
using isc.bempleo.be.domain.Models.Response.Skills;
using isc.bempleo.be.domain.Models.Request.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillResponse>();
            CreateMap<SkillRequest, Skill>();

        }
    }
}
